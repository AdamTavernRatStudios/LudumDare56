using Rewired.Integration.UnityUI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewDayPanel : MonoBehaviour
{
    public Button StartButton;
    public TextMeshProUGUI buttonText;
    Animator anim;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI FinalScoreText;

    private void Start()
    {
        anim = GetComponent<Animator>();
        GameManager.Instance.RoundEnded.AddListener(ShowPanel);
        ShowPanel();
    }

    void ShowPanel()
    {
        if (GameManager.Instance.Day < 6)
        {
            anim.SetTrigger("Enter");
            StartButton.interactable = true;
            RewiredEventSystem.current.SetSelectedGameObject(StartButton.gameObject);
            buttonText.text = "Start day: " + (GameManager.Instance.Day+1).ToString();
            MoneyText.text = "$" + ScoreManager.Instance.TotalMoney.ToString();

            ScoreManager.Instance.TotalMoney += ScoreManager.Instance.GetMoneyEarned;
        }
        else
        {
            anim.SetTrigger("EnterFinal");
            LeanTween.value(gameObject, 0, ScoreManager.Instance.CurrentRoundScore, 3f).setOnUpdate((float f) =>
            {
                FinalScoreText.text = "Final Score:" + '\n' + ((int)f).ToString();
            }).setDelay(2.5f);
        }
    }



    public void StartRound()
    {
        if (GameManager.Instance.Day < 6)
        {
            anim.SetTrigger("Exit");
            StartButton.interactable = false;
            LeanTween.value(1f, 0f, 0.5f).setOnComplete(() =>
            {
                GameManager.Instance.StartNewRound();
            });
        }
        else
        {
            anim.SetTrigger("ExitFinal");
            LeanTween.value(1f, 0f, 1.0f).setOnComplete(() =>
            {
                GameManager.Instance.StartNewRound();
            });
        }
    }
}
