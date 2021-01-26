using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class TapToPlaceObject : MonoBehaviour
{
    public GameObject placementIndicator;
    //public GameObject dogObject;
    //public GameObject catObject;

    private Pose placementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;
    private bool condition = true;

    void Start()
    {
        //arOrigin = FindObjectOfType<ARSessionOrigin>();
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (condition){
            Toast.Instance.Show("Wait for the indicator to appear then chose an object to pick", 3f);
            condition = false;
        }
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        
        /*if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }*/
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
		{
            placementIndicator.SetActive(false);
		}
	}

    private void UpdatePlacementPose()
	{
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
		{
            placementPose = hits[0].pose;
		}
	}

    private void PlaceObject(GameObject objectToPlace)
    {
        Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
    }

    public void ShowText(string textToShow){
        if (placementPoseIsValid)
        {
            Toast.Instance.Show(textToShow,2f);
        }
    }

    public void ShowObject(GameObject objectToPlace){
        if (placementPoseIsValid)
        {
            PlaceObject(objectToPlace);
        }
    }
}