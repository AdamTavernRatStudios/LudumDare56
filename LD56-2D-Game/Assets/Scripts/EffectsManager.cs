using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance { get; private set; }

    [SerializeField]
    private TextPopUp TextPopUpPrefab;

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

    public void ShowTextPopup(Flea f, string message, Color c, float rotationRange = 20f, float height = 3f, float duration = 1f)
    {
        var popup = Instantiate(TextPopUpPrefab, f.transform.position, Quaternion.identity);
        popup.Setup(message, c, rotationRange, height, duration);
    }
}
