using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeablePrefab;

    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        GameObject newPrefab;

        foreach(GameObject prefab in placeablePrefab)
        {
            if(!GlobalVariable.listAtom.ContainsKey(prefab.name))
            {
                newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                newPrefab.name = prefab.name;
                newPrefab.SetActive(false);
                GlobalVariable.listAtom.Add(prefab.name, newPrefab);
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
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;
        GameObject prefab = GlobalVariable.listAtom[name]; 

        if (trackedImage.trackingState == TrackingState.Limited)
        {
            prefab.SetActive(false);
            GlobalVariable.currentImages.Remove(name);
        }
        else if(trackedImage.trackingState == TrackingState.Tracking)
        {
            prefab.transform.position = position;
            prefab.SetActive(true);
            GlobalVariable.currentImages.Add(name);
        }
    }
}
