using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundWidget : MonoBehaviour
{
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.RoundStarted.AddListener(UpdateRoundText);
    }

    void OnDisable()
    {
        GameManager.Instance.RoundStarted.RemoveListener(UpdateRoundText);
    }

    private void UpdateRoundText()
    {
        roundText.text = "Day " + GameManager.Instance.Day.ToString() + ":";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
