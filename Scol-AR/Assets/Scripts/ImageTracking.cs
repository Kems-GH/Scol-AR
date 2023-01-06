using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField]
    private GameObject placeablePrefab;

    private ARTrackedImageManager trackedImageManager;

    public Text text;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        GameObject newPrefab;

        for (int i = 1; i <= GlobalVariable.nb_img; i++)
        {
            if (!GlobalVariable.listAtom.ContainsKey("Element_" + i))
            {
                newPrefab = Instantiate(placeablePrefab, Vector3.zero, Quaternion.identity);
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

        text.text = name;

        if (trackedImage.trackingState == TrackingState.Limited)
        {
            GlobalVariable.listAtom[name].SetActive(false);
            GlobalVariable.currentImages.Remove(name);
        }
        else if (trackedImage.trackingState == TrackingState.Tracking)
        {
            if (!GlobalVariable.currentImages.Contains(name))
            {
                GlobalVariable.currentImages.Add(name);
            }
            GlobalVariable.listAtom[name].transform.position = position;
            GlobalVariable.listAtom[name].SetActive(true);
        }
    }
}
