using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField]
    private GameObject placeablePrefab;

    private ARTrackedImageManager trackedImageManager;
    private float nextActionTimeMoins = 0.0f;
    private float nextActionTimePlus = 0.0f;
    private float period = 3.0f;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        GameObject newPrefab;

        for (int i = 1; i <= GlobalVariable.nb_elt; i++)
        {
            if (!GlobalVariable.listAtom.ContainsKey("Element_" + i))
            {
                // Créer différents atômes en fonction de la carte
                // Elément 1 ->  1 électron
                // Elément 2 ->  4 électrons
                // Elément 3 ->  7 électrons
                // Elément 4 ->  8 électrons
                // Elément 5 -> 92 électrons
                newPrefab = Instantiate(placeablePrefab, Vector3.zero, Quaternion.identity);
                switch(i)
                {
                    case 1:
                        newPrefab.GetComponent<Atome>().CreateElectrons(1);
                        break;
                    case 2:
                        newPrefab.GetComponent<Atome>().CreateElectrons(4);
                        break;
                    case 3:
                        newPrefab.GetComponent<Atome>().CreateElectrons(7);
                        break;
                    case 4:
                        newPrefab.GetComponent<Atome>().CreateElectrons(8);
                        break;
                    case 5:
                        newPrefab.GetComponent<Atome>().CreateElectrons(92);
                        break;
                }

                newPrefab.name = "Element_" + i;
                newPrefab.SetActive(false);
                GlobalVariable.listAtom.Add("Element_" + i, newPrefab);
            }
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            GlobalVariable.listAtom[trackedImage.name].SetActive(false);
            GlobalVariable.currentImages.Remove(trackedImage.name);
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;
        int nbElectrons;

        if (trackedImage.trackingState == TrackingState.Limited)
        {
            GlobalVariable.listAtom[name].SetActive(false);
            GlobalVariable.currentImages.Remove(name);
        }
        else if (trackedImage.trackingState == TrackingState.Tracking)
        {
            if (GlobalVariable.currentImages.Count != 0)
            {
                PlusMoins(name);

                foreach (string currentImage in GlobalVariable.currentImages)
                {
                    nbElectrons = GlobalVariable.listAtom[currentImage].GetComponent<Atome>().GetNbElectrons();
                    if (nbElectrons == 92)
                    {
                        GlobalVariable.animationToPlay = "Fission";
                    }
                    else if (nbElectrons == 8)
                    {
                        GlobalVariable.animationToPlay = "Eau";
                    }
                    else
                    {
                        GlobalVariable.animationToPlay = "";
                    }
                }
            }
            

            if (!GlobalVariable.currentImages.Contains(name))
            {
                GlobalVariable.currentImages.Add(name);
            }
            GlobalVariable.listAtom[name].transform.position = position;
            GlobalVariable.listAtom[name].SetActive(true);
        }
    }

    private void PlusMoins(string name)
    {
        int nbElectrons;
        if (name == "Moins" && nextActionTimeMoins < Time.time)
        {
            nextActionTimeMoins = Time.time + period;
            foreach (string currentImage in GlobalVariable.currentImages)
            {
                nbElectrons = GlobalVariable.listAtom[currentImage].GetComponent<Atome>().GetNbElectrons();
                if (nbElectrons > 1)
                {
                    GlobalVariable.listAtom[currentImage].GetComponent<Atome>().UpdateElectrons(nbElectrons - 1);
                    GlobalVariable.listAtom[currentImage].GetComponent<MovementElectron>().Init();
                }
            }
        }
        else if (name == "Plus" && nextActionTimePlus < Time.time)
        {
            nextActionTimePlus = Time.time + period;
            foreach (string currentImage in GlobalVariable.currentImages)
            {
                nbElectrons = GlobalVariable.listAtom[currentImage].GetComponent<Atome>().GetNbElectrons();
                GlobalVariable.listAtom[currentImage].GetComponent<Atome>().UpdateElectrons(nbElectrons + 1);
                GlobalVariable.listAtom[currentImage].GetComponent<MovementElectron>().Init();
            }
        }
    }
}
