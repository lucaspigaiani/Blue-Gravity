using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    public TextMeshProUGUI nameLabel; // Reference to the UI Text displaying the name of the item
    private Skin item;
    private ClothesChanger clothesChanger;
    private PlayerMoneyController playerMoneyController;
    private InventoryController inventoryController;

    private void Start()
    {
        clothesChanger = FindObjectOfType<ClothesChanger>();
        playerMoneyController = FindObjectOfType<PlayerMoneyController>();
        inventoryController = FindObjectOfType<InventoryController>();
    }
    public void Initialize(Skin newItem)
    {
        item = newItem;
        nameLabel.text = item.label;
        // Add other UI updates here
    }

    public void OnButtonClick()
    {
        clothesChanger.SkinChanger(item);
    }

    public void SellItem() 
    {
        playerMoneyController.SellItem(item);
        inventoryController.RemoveItem(item);
        inventoryController.UpdateInventoryUI();
    }

}