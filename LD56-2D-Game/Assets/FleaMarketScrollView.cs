using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FleaMarketScrollView : MonoBehaviour
{
    public CircusObjectData circusObjectData;
    public FleaMarketButton button;
    public Transform viewportPanel;
    // Start is called before the first frame update

    private void Start()
    {
        Setup();
        GameManager.Instance.RoundStarted.AddListener(HandleRoundStarted);
        GameManager.Instance.RoundEnded.AddListener(HandleRoundEnded);
    }

    private void HandleRoundStarted()
    {
        var existingButtons = GetComponentsInChildren<FleaMarketButton>();
        for(int i = 0; i < existingButtons.Length; i++)
        {
            Destroy(existingButtons[i].gameObject);
        }
    }

    private void HandleRoundEnded()
    {
        Setup();
    }

    void Setup()
    {
        var objects = circusObjectData.data;
        objects.Sort((a, b) => a.Cost.CompareTo(b.Cost));
        foreach (var data in objects)
        {
            var newButton = Instantiate(button, viewportPanel);
            newButton.objectData = data;
        }
        StartCoroutine(Utils.DoWithFrameDelayRoutine(() => GetComponent<ScrollRect>().horizontalNormalizedPosition = 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
