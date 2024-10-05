using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    Dictionary<int, List<TrickType>> scoresDict = new();
    [HideInInspector]
    public int CurrentRoundScore = 0;

    public static UnityEvent<int> PointsAddedEvent = new UnityEvent<int>();

    public static ScoreManager Instance { get; private set; }

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

    public enum TrickType
    {
        UNKNOWN = 0,
        Jump = 1,
        Spin = 2,
        LandOnPlatform = 3,
        SpinFlea = 4,
        GetSpunByFlea = 5,
        JumpThroughHoop = 6,
    }


    void Start()
    {
        GameManager.Instance.RoundEnded.AddListener(HandleRoundEnded);
        GameManager.Instance.RoundStarted.AddListener(HandleRoundStart);
    }


    void OnDisable()
    {
        GameManager.Instance.RoundEnded.RemoveListener(HandleRoundEnded);
        GameManager.Instance.RoundStarted.RemoveListener(HandleRoundStart);
    }
    private void HandleRoundEnded()
    {
        
    }

    private void HandleRoundStart()
    {
        scoresDict.Clear();
        CurrentRoundScore = 0;
    }

    public static void AddTrick(Flea flea, TrickType trickType)
    {
        Instance?.AddTrickInternal(flea, trickType);
    }
    private void AddTrickInternal(Flea flea, TrickType trickType)
    {
        if (!scoresDict.ContainsKey(flea.FleaNumber))
        {
            scoresDict[flea.FleaNumber] = new();
            flea.ComboCounter = 0;
        }
        var tricksList = scoresDict[flea.FleaNumber];
        tricksList.Add(trickType);
        int PointsToScore = GetBaseScoreFromTrick(trickType);
        if(tricksList.Count >= 2)
        {
            // If the last two tricks were different add to the combo counter and add that to the total
            if (tricksList[tricksList.Count-1] != tricksList[tricksList.Count - 2])
            {
                flea.ComboCounter++;
            }
            else
            {
                flea.ComboCounter = 0;
            }
        }
        CurrentRoundScore += PointsToScore + flea.ComboCounter;

        var message = GetTrickName(trickType) + "! +" + PointsToScore.ToString();
        if(flea.ComboCounter > 0)
        {
            message += '\n' + "<size=60%>+" + flea.ComboCounter.ToString() + " combo!";
        }
        EffectsManager.Instance.ShowTextPopup(flea, message, flea.FleaColor);

        PointsAddedEvent.Invoke(PointsToScore + flea.ComboCounter);
    }

    public int GetBaseScoreFromTrick(TrickType type)
    {
        switch (type)
        {
            case TrickType.Jump: return 5;
            case TrickType.Spin: return 10;
            case TrickType.LandOnPlatform: return 15;
            case TrickType.SpinFlea: return 20;
            case TrickType.GetSpunByFlea: return 20;
            case TrickType.JumpThroughHoop: return 30;
            default: return 0;
        }
    }

    public string GetTrickName(TrickType type)
    {
        switch (type)
        {
            case TrickType.Jump: return "Jump";
            case TrickType.Spin: return "Twirl";
            case TrickType.LandOnPlatform: return "Land";
            case TrickType.SpinFlea: return "Twirl a flea";
            case TrickType.GetSpunByFlea: return "Be twirled";
            case TrickType.JumpThroughHoop: return "Flaming hoop";
            default: return "";
        }
    }
}
