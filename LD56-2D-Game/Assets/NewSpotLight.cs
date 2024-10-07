using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpotLight : MonoBehaviour
{
    public GameObject OverlayAll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Flea.ControlledFlea != null)
        {
            transform.position = Flea.ControlledFlea.transform.position;
            OverlayAll.SetActive(false);
        }
        else
        {
            transform.position = new Vector3(0, -200, 0);
            OverlayAll.SetActive(true);
        }
    }
}
