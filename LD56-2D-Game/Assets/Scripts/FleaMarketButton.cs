using TMPro;
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
        ObjectPlacerPanel.Instance.RecieveObject(objectData);
    }
}
