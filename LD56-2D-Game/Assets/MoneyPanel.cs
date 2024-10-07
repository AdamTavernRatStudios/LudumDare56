using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyPanel : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.MoneyChanged.AddListener(MoneyChangedHandler);
    }

    private void MoneyChangedHandler(int Old, int New)
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, Old, New, 2f).setOnUpdate((float f) =>
        {
            moneyText.text = "$" + (int)f;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
