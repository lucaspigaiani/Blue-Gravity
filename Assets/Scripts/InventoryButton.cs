using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    // Reference to the item
    public Skin item;

    // References to other components
    private ClothesChanger clothesChanger;
    private PlayerMoneyController playerMoneyController;
    private InventoryController inventoryController;

    // UI elements
    public Image icon;
    public TextMeshProUGUI objName;

    // Start is called before the first frame update
    private void Start()
    {
        // Find and store references to other components
        clothesChanger = FindObjectOfType<ClothesChanger>();
        playerMoneyController = FindObjectOfType<PlayerMoneyController>();
        inventoryController = FindObjectOfType<InventoryController>();
    }

    // Initialize the inventory button with an item
    public void Initialize(Skin newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        objName.text = item.label;
    }

    // Handle button click event
    public void OnButtonClick()
    {
        // Change the player's skin
        clothesChanger.SkinChanger(item);
    }

    // Sell the item
    public void SellItem()
    {
        // Sell the item and update inventory UI
        playerMoneyController.SellItem(item);
        inventoryController.RemoveItem(item);
        inventoryController.UpdateInventoryUI();
    }
}