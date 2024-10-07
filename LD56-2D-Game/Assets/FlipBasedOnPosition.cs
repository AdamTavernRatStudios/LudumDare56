using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBasedOnPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(transform.position.x >= 0 ? 1 : -1, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
