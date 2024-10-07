#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using static System.Net.WebRequestMethods;

public class CatalogDataParser : Editor
{
    [MenuItem("Custom Tools/Update Circus Object Data")]

    public static void UpdateScriptableObjects()
    {
        UpdateScriptableObjectsAsync();
    }

    public static string LoadTextFile(string filePath)
    {
        string text = "";

        try
        {
            text = System.IO.File.ReadAllText(filePath);
        }
        catch (IOException e)
        {
            Debug.LogError($"Error reading the file at path '{filePath}': {e.Message}");
        }

        return text;
    }

    public static async void UpdateScriptableObjectsAsync()
    {
        string url = "https://docs.google.com/spreadsheets/d/1Vs-CPxzmGuyGvwSOgmoyF43auKcTiKmHbjmVyJ8Rnrg/export?format=tsv";
        string filePath = "Assets/Scripts/CatalogObjectsData/ObjectData.txt";
        await Utils.LoadGoogleSheetAsTSV(url, filePath);

        var TextAsset = LoadTextFile(filePath);
        ParseTextAsset(TextAsset);

        // Get all asset paths in the directory
        string[] assetPaths = System.IO.Directory.GetFiles("Assets/Scripts/CatalogObjectsData", "*.asset", SearchOption.AllDirectories);

        // Loop through all asset paths
        foreach (string assetPath in assetPaths)
        {
            // Load the asset as a ScriptableObject
            CircusObjectData dataObject = AssetDatabase.LoadAssetAtPath<CircusObjectData>(assetPath);

            if (dataObject != null)
            {
                dataObject.data.Clear();
                foreach (var furniature in circusObjectDataFromFile)
                {
                    dataObject.data.Add(furniature.Value);
                }

                // Save the changes made to the ScriptableObject
                EditorUtility.SetDirty(dataObject);
                AssetDatabase.SaveAssets();

                Debug.Log($"Populated {dataObject.name} at {assetPath}");
            }
        }
    }

    private static Dictionary<string, CircusObjectDatum> circusObjectDataFromFile = new Dictionary<string, CircusObjectDatum>();

    public const string ItemName = "Item Name";
    public const string PrefabName = "Prefab Name";
    public const string Type = "Type";
    public const string Description = "Description";
    public const string TentColor = "Tent Color";
    public const string SpriteName = "Asset Name";
    public const string CostKey = "Cost";

    private static void ParseTextAsset(string strings)
    {
        circusObjectDataFromFile = new();

        string[] lines = strings.Split('\n');
        var variableIDs = lines[0].Split('\t');
        for (int r = 1; r < lines.Length; r++)
        {
            var line = lines[r];
            string[] columns = line.Split('\t'); // Assuming tab-separated values

            if (columns.Length < 3)
            {
                Debug.LogError("Not enough columns in this weapondata for " + columns[0]);
                continue;
            }
            CircusObjectDatum CircusObject = new();

            for (int c = 0; c < columns.Length; c++)
            {
                var variableID = variableIDs[c].Trim();
                var dataString = columns[c].Trim();
                switch (variableID)
                {
                    case ItemName:
                        CircusObject.ObjectName = dataString;
                        break;
                    case Type:
                        switch (dataString)
                        {
                            case "Between Platforms": CircusObject.objectType = CircusObjectDatum.ObjectType.BetweenPlatforms; break;
                            case "On Standard Platform": CircusObject.objectType = CircusObjectDatum.ObjectType.OnPlatform; break;
                            case "Platform": CircusObject.objectType = CircusObjectDatum.ObjectType.Platform; break;
                        }
                        break;
                    case Description:
                        CircusObject.Description = dataString;
                        break;
                    case TentColor:
                        CircusObject.TentColor = dataString;
                        break;
                    case CostKey:
                        CircusObject.Cost = int.Parse(dataString);
                        break;
                    case PrefabName:
                        CircusObject.ObjectPrefab = FindAndAssignPrefab(dataString);
                        break;
                    case SpriteName:
                        CircusObject.sprite = FindSprite(dataString);
                        break;
                }
            }

            circusObjectDataFromFile.Add(CircusObject.ObjectName, CircusObject);
        }
    }

    public static GameObject FindAndAssignPrefab(string prefabName)
    {
        // Get all prefab assets in the given folder path
        string[] assetPaths = System.IO.Directory.GetFiles("Assets/Prefabs/CircusItemObjects", "*.prefab", SearchOption.AllDirectories);
        // string[] prefabGUIDs = AssetDatabase.FindAssets(prefabName, new[] { "Assets/Preabs/CircusItemObjects" });

        // Loop through all found prefabs
        foreach (string assetpath in assetPaths)
        {

            // Load the asset as a GameObject (prefab)
            GameObject loadedPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetpath);

            // Check if the name of the loaded prefab matches the search name
            if (loadedPrefab != null && loadedPrefab.name == prefabName)
            {
                return loadedPrefab;
            }
        }
        return null;
    }

    public static Sprite FindSprite(string spriteName)
    {
        string[] guids = AssetDatabase.FindAssets("t:Sprite", new[] { "Assets/Sprites" });
        foreach (var g in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(g);
            var asset = AssetDatabase.LoadAssetAtPath<Sprite>(path);
            if(asset.name == spriteName)
            {
                return asset;
            }
        }
        return null;
    }
}
#endif
