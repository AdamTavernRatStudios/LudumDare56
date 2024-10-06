using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatalogUIWidget : MonoBehaviour
{
    public FleaMarketButton CatalogButton;
    public ScrollRect scrollRect;

    public static CatalogUIWidget Instance { get; private set; }

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

    // Start is called before the first frame update
    void Start()
    {
        LoadInventory();
    }

    public void LoadInventory()
    {
        /*
        var buttons = GetComponentsInChildren<FleaMarket>();
        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }
        var sortedList = GameManager.Instance.Inventory.OrderByDescending((f) => f.Type).ToList();
     
        foreach (var f in sortedList)
        {
            var newButton = Instantiate(CatalogButton, transform);
            newButton.furnituredata = f;
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = f.Furniture_name;
        }
        StartCoroutine(Utils.DoWithFrameDelay(() => scrollRect.verticalScrollbar.value = 1f));*/
    }
}
