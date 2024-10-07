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
    }
    void Setup()
    {
        var objects = circusObjectData.data;
        objects.Sort((a, b) => a.objectType.CompareTo(b.objectType));
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
