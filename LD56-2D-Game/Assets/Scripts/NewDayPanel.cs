using Rewired.Integration.UnityUI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewDayPanel : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Button StartButton;
    public TextMeshProUGUI buttonText;
    Animator anim;
    public TextMeshProUGUI MoneyText;

    private void Start()
    {
        anim = GetComponent<Animator>();
        GameManager.Instance.RoundEnded.AddListener(ShowPanel);
        ShowPanel();
    }

    void ShowPanel()
    {
        anim.SetTrigger("Enter");
        StartButton.interactable = true;
        RewiredEventSystem.current.SetSelectedGameObject(StartButton.gameObject);
        buttonText.text = "Start day: " + (GameManager.Instance.Day+1).ToString();
        MoneyText.text = "$" + ScoreManager.Instance.TotalMoney.ToString();
    
        ScoreManager.Instance.TotalMoney += ScoreManager.Instance.CurrentRoundScore / 10;
    }

    public void StartRound()
    {
        anim.SetTrigger("Exit");
        StartButton.interactable = false;
        LeanTween.value(1f, 0f, 0.5f).setOnComplete(() =>
        {
            canvasGroup.blocksRaycasts = true;
            GameManager.Instance.StartNewRound();
        });
    }
}
