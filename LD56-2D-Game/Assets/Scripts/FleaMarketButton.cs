using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FleaMarketButton : MonoBehaviour
{
    public CircusObjectDatum objectData;

    public TextMeshProUGUI MainText;
    public TextMeshProUGUI cost; 
    public Image image;
    public Image background;

    private void Start()
    {
        MainText.text = objectData.ObjectName + "<size=50%>" + '\n' + objectData.Description;
        image.sprite = objectData.sprite;
        cost.text = objectData.Cost.ToString();
        background.color = Utils.HexToColor(objectData.TentColor);
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
