using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{
    public Skin item; // Reference to the ScriptableObject representing the item
    
    private Button button;
    private Image icon;
    private TextMeshProUGUI price;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        // Get the icon and price components from children
        Transform childTransform = transform.Find("Icon"); // Replace "Icon" with the name of your child GameObject
        icon = childTransform.GetComponent<Image>();
        price = GetComponentInChildren<TextMeshProUGUI>();


        SetButton();
    }

    private void SetButton() 
    {
        icon.sprite = item.icon;
        price.text = item.value.ToString();
    }
    private void OnButtonClick()
    {
        if (item != null)
        {
            ShopManager.Instance.BuyItem(item);
        }
    }

    // Called when the mouse enters the button's collider
    private void OnMouseEnter()
    {
        Debug.Log("Mouse entered over the button");
        // You can add additional logic here if needed
    }

    // Called when the mouse exits the button's collider
    private void OnMouseExit()
    {
        Debug.Log("Mouse exited from the button");
        // You can add additional logic here if needed
    }
}