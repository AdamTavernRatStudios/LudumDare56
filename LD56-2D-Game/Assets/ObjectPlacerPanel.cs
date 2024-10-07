using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ObjectPlacerPanel : MonoBehaviour
{
    public CircusObjectData objectData;
    [HideInInspector]
    public CircusObjectDatum currentObject;
    public GameObject PlaceObjectButtonPrefab;
    public NewDayPanel newdaypanel;
    public GameObject BasePlatform;


    public static ObjectPlacerPanel Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        GameManager.Instance.RoundStarted.AddListener(ResetObjects);
    }

    public void RecieveObject(CircusObjectDatum currObject)
    {
        LoadButtonsForPlacement(currObject);
        newdaypanel.gameObject.SetActive(false);
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

        StartCoroutine(ShowPanelOnDelay());
    }

    IEnumerator ShowPanelOnDelay()
    {
        yield return new WaitForSeconds(1);
        newdaypanel.gameObject.SetActive(true);
    }

    void ResetObjects()
    {
        var keys = ObjectPlacementPoints.Instance.PlacedObjectsDictionary.Keys.ToList();
        for(int i = 0; i < keys.Count; i++)
        {
            var spot = keys[i];
            var obj = ObjectPlacementPoints.Instance.PlacedObjectsDictionary[spot];
            if(obj == null)
            {
                continue;
            }
            ObjectPlacementPoints.Instance.PlacedObjectsDictionary[spot] = Instantiate(obj, spot.position, Quaternion.identity);
            Destroy(obj);
        }
    }
}
