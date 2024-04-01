using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public Skin item; // Reference to the ScriptableObject representing the item

    private Button button;
    public bool isBuying;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (item != null)
        {
            if (isBuying)
            {
                // Pass the price of the item to the shop manager
                ShopManager.Instance.BuyItem(item);
            }
            else
            {
                ShopManager.Instance.SellItem(item);
            }
           
        }
    }
}