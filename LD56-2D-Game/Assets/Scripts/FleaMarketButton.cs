using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FleaMarketButton : MonoBehaviour
{
    public CircusObjectData fleamarketdata;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI cost; 
    public Image image;

    private void Start()
    {
        //titleText.text = fleamarketdata.Furniture_name;
       // descriptionText.text = fleamarketdata.Description;
       // image.sprite = fleamarketdata.MainSprite;
    }

    public void LoadFleaMarketItems()
    {
        //ObjectDroppingManager.Instance.CreateNewFleaMarketItems(fleamarketdata);
    }

  
}
