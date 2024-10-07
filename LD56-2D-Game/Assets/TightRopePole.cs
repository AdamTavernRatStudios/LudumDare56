using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TightRopePole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var top = GetComponentInParent<TightRope>();
        var height = top.transform.position.y - Floor.Instance.transform.position.y;
        transform.localScale = new Vector3(transform.localScale.x, height, 1f);
        transform.localPosition = new Vector3(transform.localPosition.x, -height / 2, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
