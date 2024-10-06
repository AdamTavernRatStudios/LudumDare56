using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacerPanel : MonoBehaviour
{
    public CircusObjectData objectData;
    [HideInInspector]
    public CircusObjectDatum currentObject;
    public GameObject PlaceObjectButtonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        currentObject = objectData.data[5];
        LoadButtonsForPlacement(currentObject);
    }

    public void LoadButtonsForPlacement(CircusObjectDatum currObject)
    {
        currentObject = currObject;
        List<Transform> positions = new List<Transform>();
        if(currentObject.objectType == CircusObjectDatum.ObjectType.Platform)
        {
            positions = ObjectPlacementPoints.Instance.PlatformSpots;
        }
        if (currentObject.objectType == CircusObjectDatum.ObjectType.OnPlatform)
        {
            positions = ObjectPlacementPoints.Instance.PlatformObjectSpots;
        }
        if (currentObject.objectType == CircusObjectDatum.ObjectType.BetweenPlatforms)
        {
            positions = ObjectPlacementPoints.Instance.BetweenSpots;
        }
        foreach(var pos in positions)
        {
            var newButton = Instantiate(PlaceObjectButtonPrefab, this.transform);
            newButton.GetComponent<MatchWorldObjectPosition>().worldObject = pos;
            newButton.GetComponent<PlaceObjectButton>().placerPanel = this;
        }
    }

    public void ClearButtons()
    {
        var placerButtons = GetComponentsInChildren<PlaceObjectButton>();
        foreach(var b in placerButtons)
        {
            Destroy(b.gameObject);
        }
    }
}
