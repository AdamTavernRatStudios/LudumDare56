using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectButton : MonoBehaviour
{
    public ObjectPlacerPanel placerPanel;
    MatchWorldObjectPosition matchpos;
    public GameObject CreationParticles = null;
    private void Start()
    {
        matchpos = GetComponent<MatchWorldObjectPosition>();
    }
    public void PlaceCurrentObjectHere()
    {
        if(ObjectPlacementPoints.Instance.PlacedObjectsDictionary.TryGetValue(matchpos.worldObject, out GameObject ExistingObject))
        {
            Destroy(ExistingObject);
            if (placerPanel.currentObject.objectType == CircusObjectDatum.ObjectType.Platform)
            {
                var childPos = matchpos.worldObject.GetChild(0).transform;
                if (ObjectPlacementPoints.Instance.PlacedObjectsDictionary.TryGetValue(childPos, out GameObject platformObj))
                {
                    Destroy(platformObj);
                    ObjectPlacementPoints.Instance.PlacedObjectsDictionary[matchpos.worldObject] = null;
                }
            }
        }
        ObjectPlacementPoints.Instance.PlacedObjectsDictionary[matchpos.worldObject] = Instantiate(placerPanel.currentObject.ObjectPrefab, matchpos.worldObject.position, Quaternion.identity);
        Instantiate(CreationParticles, matchpos.worldObject.position, Quaternion.identity);
        placerPanel.ClearButtons();
    }
}
