using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static List<List<Flea.FrameInput>> RecordedInputs = new();
    public Flea FleaPrefab;
    public static GameManager Instance { get; private set; }
    public int Day = 0;
    public UnityEvent RoundEnded = new();
    public UnityEvent RoundStarted = new();

    public Transform SpotlightSource = null;
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

    // Start is called before the first frame update
    void Start()
    {
        RecordedInputs.Clear();
        EndRound();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EndRound();
        }
    }
    private void StopCurrentFleas()
    {
        var fleas = GameObject.FindObjectsOfType<Flea>();
        for (int i = 0; i < fleas.Length; i++)
        {
            if (!fleas[i].UseRecordedData)
            {
                RecordedInputs.Add(fleas[i].inputs);
                fleas[i].enabled = false;
            }
        }
    }
    private void ResetFleas(bool WatchingShow = false)
    {
        var fleas = GameObject.FindObjectsOfType<Flea>();
        for(int i = 0; i < fleas.Length; i++)
        {
            Destroy(fleas[i].gameObject);
        }
        for(int i = 0; i < RecordedInputs.Count; i++)
        {
            var newFlea = Instantiate(FleaPrefab);
            newFlea.FleaNumber = i;
            newFlea.UseRecordedData = true;
        }
        if (!WatchingShow)
        {
            // Make new player flea
            var flea = Instantiate(FleaPrefab);
            flea.FleaNumber = RecordedInputs.Count;
        }
    }

    bool DayIsOccuring = false;
    public void EndRound()
    {
        if (!DayIsOccuring) return;

        DayIsOccuring = false;
        StopCurrentFleas();
        RoundEnded.Invoke();
    }
    public void StartNewRound()
    {
        if (DayIsOccuring) return;

        if(Day >= 6)
        {
            WatchTheShow();
            return;
        }
        DayIsOccuring = true;
        ResetFleas();
        Day++;
        RoundStarted.Invoke();
    }

    public void WatchTheShow()
    {
        if (DayIsOccuring) return;

        DayIsOccuring = true;
        ResetFleas(true);
        RoundStarted.Invoke();
    }
}
