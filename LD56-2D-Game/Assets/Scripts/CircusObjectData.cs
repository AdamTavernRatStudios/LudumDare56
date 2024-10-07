using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CatalogItemData", menuName = "Custom/CatalogItemData")]
public class CircusObjectData : ScriptableObject
{
    public List<CircusObjectDatum> data = new();
}

[Serializable]
public class CircusObjectDatum
{
    public enum ObjectType
    {
        UNKNOWN,
        Platform,
        OnPlatform,
        BetweenPlatforms,
    }
    public string ObjectName = "ObjectName";
    public string Description = "DescriptionHere";
    public string TentColor = "FFFFFFFF";
    public Sprite sprite = null;
    public ObjectType objectType = ObjectType.UNKNOWN;
    public int Cost = 100;
    public GameObject ObjectPrefab;
}
