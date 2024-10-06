using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectButton : MonoBehaviour
{
    public ObjectPlacerPanel placerPanel;
    MatchWorldObjectPosition matchpos;
    private void Start()
    {
        matchpos = GetComponent<MatchWorldObjectPosition>();
    }
    public void PlaceCurrentObjectHere()
    {
        Instantiate(placerPanel.currentObject.ObjectPrefab, matchpos.worldObject.position, Quaternion.identity);
        placerPanel.ClearButtons();
    }
}
