using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{
    public Skin item; // Reference to the ScriptableObject representing the item

    private Button button;
    private Image icon;
    private TextMeshProUGUI price;

    // Initialize button components and set item details
    private void Start()
    {
        // Get the button component and add a listener to handle clicks
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        // Find the icon and price components from children
        Transform childTransform = transform.Find("Icon"); // Replace "Icon" with the name of your child GameObject
        icon = childTransform.GetComponent<Image>();
        price = GetComponentInChildren<TextMeshProUGUI>();

        // Set the button's icon and price
        SetButton();
    }

    // Set the button's icon and price
    private void SetButton()
    {
        icon.sprite = item.icon;
        price.text = item.value.ToString();
    }

    // Called when the button is clicked
    private void OnButtonClick()
    {
        if (item != null)
        {
            ShopManager.Instance.BuyItem(item);
        }
    }
}