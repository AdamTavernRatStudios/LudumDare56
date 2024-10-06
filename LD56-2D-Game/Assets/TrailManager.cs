using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    TrailRenderer trail;
    Flea flea;
    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        flea = GetComponentInParent<Flea>();
    }

    // Update is called once per frame
    void Update()
    {
        trail.enabled = !flea.rb.isKinematic;
    }
}
