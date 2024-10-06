using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCatalogManager : MonoBehaviour
{
    public static ObjectCatalogManager Instance { get; private set; }

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

    public List<CircusObjectData> CatalogObjects = new();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
