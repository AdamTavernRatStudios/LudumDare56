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

    private void Start()
    {
        GameManager.Instance.RoundEnded.AddListener(ShowPanel);
        ShowPanel();
    }

    private void OnDisable()
    {
        GameManager.Instance.RoundEnded.RemoveListener(ShowPanel);
    }

    void ShowPanel()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 0f;
        LeanTween.value(0f, 1f, 0.5f).setOnUpdate((f) => canvasGroup.alpha = f);
        StartButton.interactable = true;
        RewiredEventSystem.current.SetSelectedGameObject(StartButton.gameObject);
        buttonText.text = "Start day: " + (GameManager.Instance.Day+1).ToString();
    }

    public void StartRound()
    {
        StartButton.interactable = false;
        LeanTween.value(1f, 0f, 0.5f).setOnUpdate((f) => canvasGroup.alpha = f).setOnComplete(() =>
        {
            canvasGroup.blocksRaycasts = true;
            GameManager.Instance.StartNewRound();
        });
    }
}
