using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    public float TimePerDay = 60f;
    public float TimeElapsed = 0f;

    public Slider timerSlider;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.RoundStarted.AddListener(StartTimer);
        GameManager.Instance.RoundEnded.AddListener(StopTimer);
    }

    void OnDisable()
    {
        GameManager.Instance.RoundStarted.AddListener(StartTimer);
        GameManager.Instance.RoundEnded.AddListener(StopTimer);
    }

    bool TimerIsRunning = false;
    private void StartTimer()
    {
        TimerIsRunning = true;
        TimeElapsed = 0f;
    }

    private void StopTimer()
    {
        timerSlider.value = 1f;
        TimerIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TimerIsRunning)
        {
            return;
        }
        var PercentComplete = Mathf.Clamp(TimeElapsed / TimePerDay, 0f, 1f);
        timerSlider.value = PercentComplete;
        TimeElapsed += Time.deltaTime;
        if(TimeElapsed > TimePerDay)
        {
            GameManager.Instance.EndRound();
        }
    }
}
