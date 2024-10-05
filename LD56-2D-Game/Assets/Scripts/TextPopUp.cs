using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    public TextMeshProUGUI textmesh;
    // Start is called before the first frame update

    public void Setup(string message, Color c, float rotationRange = 5f, float height = 3f, float duration = 1f)
    {
        textmesh.text = message;
        textmesh.color = c;
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-rotationRange, rotationRange));
        LeanTween.moveLocal(textmesh.gameObject, Vector3.up * height, duration).setEaseOutBack();
        LeanTween.value(textmesh.gameObject, 1f, 0f, duration / 4f).setDelay(3f * duration / 4f).setOnUpdate((float f) =>
        {
            var c = textmesh.color;
            c.a = f;
            textmesh.color = c;
        });
        Destroy(gameObject, duration);
    }
    public void Setup(string message, float rotationRange = 5f, float height = 3f, float duration = 1f)
    {
        Setup(message, Color.white, rotationRange, height, duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
