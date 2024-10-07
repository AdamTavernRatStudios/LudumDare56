using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FleaMarketButton : MonoBehaviour
{
    public CircusObjectDatum objectData;

    public TextMeshProUGUI MainText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI cost; 
    public Image image;
    public Image background;

    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        MainText.text = objectData.ObjectName;
        DescriptionText.text = objectData.Description;
        image.sprite = objectData.sprite;
        cost.text = objectData.Cost.ToString();
        background.color = Utils.HexToColor(objectData.TentColor);
    }

    private void Update()
    {
        button.interactable = objectData.Cost <= ScoreManager.Instance.TotalMoney;
    }

    public void SetAsCurrentObject()
    {
        if(objectData.Cost <= ScoreManager.Instance.TotalMoney)
        {
            ScoreManager.Instance.TotalMoney -= objectData.Cost;
            ObjectPlacerPanel.Instance.RecieveObject(objectData);
        }
    }
}
