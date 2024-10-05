using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<List<Flea.FrameInput>> RecordedInputs = new();
    public Flea FleaPrefab;
    // Start is called before the first frame update
    void Start()
    {
        RecordedInputs.Clear();
        ResetFleas();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetFleas();
        }
    }

    private void ResetFleas()
    {
        var fleas = GameObject.FindObjectsOfType<Flea>();
        for(int i = 0; i < fleas.Length; i++)
        {
            if (!fleas[i].UseRecordedData)
            {
                RecordedInputs.Add(fleas[i].inputs);
            }
            Destroy(fleas[i].gameObject);
        }
        for(int i = 0; i < RecordedInputs.Count; i++)
        {
            var newFlea = Instantiate(FleaPrefab);
            newFlea.FleaNumber = i;
            newFlea.UseRecordedData = true;
        }
        // Make new player flea
        var flea = Instantiate(FleaPrefab);
        flea.FleaNumber = RecordedInputs.Count;

    }
}
