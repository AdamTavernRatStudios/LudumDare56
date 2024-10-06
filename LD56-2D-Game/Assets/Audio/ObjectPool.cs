using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    Dictionary<string, List<GameObject>> objectsDictionary = new();
    Dictionary<string, int> indexDictionary = new();

    Dictionary<string, GameObject> stringToObjectDictionary = new();

    [Serializable]
    public struct PooledObject
    {
        public GameObject pooledObject;
        public int amountToPool;
    }

    [SerializeField]
    public List<PooledObject> objectsToPool;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnEnable()
    {
        foreach (PooledObject obj in objectsToPool)
        {
            PoolObjects(obj.pooledObject, obj.amountToPool);
        }
    }

    public void PoolObjects(GameObject obj, int num)
    {
        indexDictionary[obj.name] = 0;
        for (int i = 0; i < num; i++)
        {
            GameObject newObject = Instantiate(obj, this.transform);
            newObject.SetActive(false);
            if (!objectsDictionary.ContainsKey(obj.name))
            {
                objectsDictionary[obj.name] = new List<GameObject>();
                stringToObjectDictionary.Add(obj.name, obj);
            }
            objectsDictionary[obj.name].Add(newObject);
        }
    }

    public GameObject AddObjectToPool(GameObject obj)
    {
        GameObject newObject = Instantiate(obj, this.transform);
        newObject.SetActive(false);
        if (!objectsDictionary.ContainsKey(obj.name))
        {
            objectsDictionary[obj.name] = new List<GameObject>();
        }
        objectsDictionary[obj.name].Add(newObject);
        return newObject;
    }

    public GameObject GetObjectFromPool(GameObject GameObject)
    {
        var result = GetObjectFromPool(GameObject.name);
        if (result == null)
        {
            return AddObjectToPool(GameObject);
        }
        return result;
    }

    private GameObject GetObjectFromPool(string GameObjectName)
    {
        if (!indexDictionary.ContainsKey(GameObjectName))
        {
            Debug.LogError("Could not find gameObject:" + GameObjectName + " in pooled objects dictionary");
            return null;
        }

        int startingIndex = indexDictionary[GameObjectName];
        List<GameObject> listOfPooledObjects = objectsDictionary[GameObjectName];
        int listSize = listOfPooledObjects.Count;

        if (listSize > 0)
        {
            for (int i = (startingIndex + 1) % listSize; (i % listSize) != startingIndex; i = (i + 1) % listSize)
            {
                if (!listOfPooledObjects[i].activeInHierarchy)
                {
                    indexDictionary[GameObjectName] = i;
                    return listOfPooledObjects[i];
                }
            }
        }

        Debug.Log("Could not get another " + GameObjectName + " from the Object Pool!");
        return null;
    }

    public GameObject Instantiate(GameObject gameObject)
    {
        return instantiate(gameObject, Vector3.zero, Quaternion.identity);
    }

    public GameObject Instantiate(GameObject gameObject, Vector3 position)
    {
        return instantiate(gameObject, position, Quaternion.identity);
    }

    public GameObject instantiate(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        GameObject createdObject = GetObjectFromPool(gameObject);
        if (createdObject != null)
        {
            createdObject.SetActive(true);

            createdObject.transform.position = position;
            createdObject.transform.rotation = rotation;
        }
        // Debug.Log("Got Pooled object " + gameObject.name + " at position " + position.ToString());
        return createdObject;
    }

    public GameObject Instantiate(string gameObjectName)
    {
        return Instantiate(gameObjectName, Vector3.zero, Quaternion.identity);
    }

    public GameObject Instantiate(string gameObjectName, Vector3 position)
    {
        return Instantiate(gameObjectName, position, Quaternion.identity);
    }

    public GameObject Instantiate(string gameObjectName, Vector3 position, Quaternion rotation)
    {
        var gameobject = stringToObjectDictionary[gameObjectName];
        GameObject createdObject = GetObjectFromPool(gameobject);
        if (createdObject != null)
        {
            createdObject.SetActive(true);

            createdObject.transform.position = position;
            createdObject.transform.rotation = rotation;
        }
        else
        {
            createdObject = instantiate(gameobject, position, Quaternion.identity);
        }
        // Debug.Log("Got Pooled object " + gameObject.name + " at position " + position.ToString());
        return createdObject;
    }

    private void OnDisable()
    {
        for (int i = 0; i < objectsDictionary.Count; i++)
        {
            var item = objectsDictionary.ElementAt(i);
            objectsDictionary[item.Key] = new List<GameObject>();
            indexDictionary[item.Key] = 0;
        }
    }
}