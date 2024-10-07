using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchWorldObjectPosition : MonoBehaviour
{
    public Camera mainCamera => Camera.main;        // The camera used to render the world (usually the main camera)
    RectTransform uiElement;  // The UI element you want to position (must be in a Canvas)
    public Transform worldObject;    // The 3D object in the world you want to track
    public Vector3 AdditionalOffset = Vector3.zero;

    private void Start()
    {
        uiElement = GetComponent<RectTransform>();
    }
    private void Update()
    {
        PositionUIOverWorldObject();
    }

    // Method to position the UI element on top of the world object
    private void PositionUIOverWorldObject()
    {
        if (worldObject == null || uiElement == null || mainCamera == null)
        {
            return;
        }

        // Convert the world position to screen space
        Vector3 screenPos = mainCamera.WorldToScreenPoint(worldObject.position);

        // Check if the world object is in front of the camera (positive z)
        if (screenPos.z > 0)
        {
            // Convert screen space to UI canvas space and set the position
            uiElement.position = screenPos + AdditionalOffset;
        }
        else
        {
            // If the object is behind the camera, you might want to hide the UI element
            uiElement.gameObject.SetActive(false);
        }
    }
}
