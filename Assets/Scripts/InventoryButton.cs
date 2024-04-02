using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    public Skin item;
    private ClothesChanger clothesChanger;
    private PlayerMoneyController playerMoneyController;
    private InventoryController inventoryController;
    public Image icon;
    public TextMeshProUGUI objName;

    private void Start()
    {
        clothesChanger = FindObjectOfType<ClothesChanger>();
        playerMoneyController = FindObjectOfType<PlayerMoneyController>();
        inventoryController = FindObjectOfType<InventoryController>();

    }
    public void Initialize(Skin newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        objName.text = item.label;
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