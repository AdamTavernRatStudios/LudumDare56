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
    private int _TotalMoney = 100;
    public int TotalMoney
    {
        get
        {
            return _TotalMoney;
        }
        set
        {
            var oldVal = _TotalMoney;
            _TotalMoney = value;
            MoneyChanged.Invoke(oldVal, _TotalMoney);
        }
    }
    public int GetMoneyEarned => CurrentRoundScore / 10;
    public UnityEvent<int, int> MoneyChanged;

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
        SpinFlea = 3,
        GetSpunByFlea = 4,
        LandOnPlatform = 5,
        LandOnBonusPlatform = 6,
        JumpThroughHoop = 7,
        EnterCannon = 12,
        CannonBlast = 8,
        PogoStickBounce = 9,
        TrampolineBounce = 10,
        GrabTrapese = 11,
        ExitTrapese = 13,
        EnterTightRope = 14,
        WalkOnTightRope = 15,
        ExitTightRope = 16,
        EnterGlobe = 17,
        WalkOnGlobe = 18,
        ExitGlobe = 19,
        BubbleBounce = 20,
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && Application.isEditor){
            TotalMoney += 10000;
        }
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
        int HeightBonus = Mathf.Max(0,(int)(flea.transform.position.y - Floor.FloorHeight) / 2);
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
        CurrentRoundScore += (PointsToScore + HeightBonus) + flea.ComboCounter;

        var message = GetTrickName(trickType) + "! +" + (PointsToScore + HeightBonus).ToString();
        if(flea.ComboCounter > 0)
        {
            message += '\n' + "<size=60%>+" + flea.ComboCounter.ToString() + " combo!</size>";
        }
        EffectsManager.Instance.ShowTextPopup(flea, message, flea.FleaColor);

        AudioManager.PlayClip(Audio.Clips.FleaNoises);
        PointsAddedEvent.Invoke((PointsToScore + HeightBonus) + flea.ComboCounter);
    }

    public int GetBaseScoreFromTrick(TrickType type)
    {
        switch (type)
        {
            case TrickType.Jump: return 5;
            case TrickType.Spin: return 10;
            case TrickType.LandOnPlatform: return 15;
            case TrickType.SpinFlea: return 20;
            case TrickType.GetSpunByFlea: return 50;
            case TrickType.JumpThroughHoop: return 30;
            case TrickType.CannonBlast: return 20;
            case TrickType.PogoStickBounce: return 30;
            case TrickType.TrampolineBounce: return 10;
            case TrickType.LandOnBonusPlatform:  return 25;
            case TrickType.EnterCannon:  return 5;
            case TrickType.GrabTrapese:  return 35;
            case TrickType.ExitTrapese:  return 35;
            case TrickType.EnterTightRope:  return 20;
            case TrickType.WalkOnTightRope:  return 100;
            case TrickType.ExitTightRope:  return 20;
            case TrickType.EnterGlobe:  return 5;
            case TrickType.WalkOnGlobe:  return 20;
            case TrickType.ExitGlobe:  return 5;
            case TrickType.BubbleBounce:  return 40;
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
            case TrickType.CannonBlast: return "Cannon";
            case TrickType.PogoStickBounce: return "Pogo";
            case TrickType.TrampolineBounce: return "Trampoline";
            case TrickType.LandOnBonusPlatform: return "Stuck landing";
            case TrickType.EnterCannon: return "Enter cannon";
            case TrickType.GrabTrapese: return "Trapese grab";
            case TrickType.ExitTrapese: return "Trapese jump";
            case TrickType.EnterTightRope: return "Land on tightrope";
            case TrickType.WalkOnTightRope: return "Balance";
            case TrickType.ExitTightRope: return "Jump from tightrope";
            case TrickType.EnterGlobe: return "Land on globe";
            case TrickType.WalkOnGlobe: return "Balance on globe";
            case TrickType.ExitGlobe: return "Jump off globe";
            case TrickType.BubbleBounce: return "Bubble bounce";
            default: return "";
        }
    }
}
