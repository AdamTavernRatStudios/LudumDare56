using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementPoints : MonoBehaviour
{
    public static ObjectPlacementPoints Instance { get; private set; }

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

    public List<Transform> PlatformSpots;
    public List<Transform> PlatformObjectSpots;
    public List<Transform> BetweenSpots;
    // Start is called before the first frame update
    void Start()
    {
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach(var sprite in sprites)
        {
            sprite.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
