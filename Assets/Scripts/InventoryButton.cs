using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    public TextMeshProUGUI nameLabel; // Reference to the UI Text displaying the name of the item
    private Skin item;

    public void Initialize(Skin newItem)
    {
        item = newItem;
        nameLabel.text = item.label;
        // Add other UI updates here
    }

    public void OnButtonClick()
    {
        // Handle interactions with the item in the inventory
    }
}