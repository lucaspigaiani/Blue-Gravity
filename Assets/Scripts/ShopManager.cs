using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    public PlayerMoneyController playerMoneyController;
    public InventoryController inventoryController;

    private DialogBoxManager dialogBoxManager;

    public Skin[] storeItems;
    public GameObject shopButtonPrefab;
    public GameObject storeContent;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        dialogBoxManager = GameObject.FindGameObjectWithTag("DialogBoxManager").GetComponent<DialogBoxManager>();
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < storeItems.Length; i++)

        {  // Instantiate the prefab associated with ShopButton component
            GameObject buttonGO = Instantiate(shopButtonPrefab, storeContent.transform);

            // Get the ShopButton component from the instantiated GameObject
            ShopButton newItem = buttonGO.GetComponent<ShopButton>();

            // Set the item for the ShopButton
            newItem.item = storeItems[i];
        }
    }

    public void BuyItem(Skin item)
    {
        if (inventoryController != null && playerMoneyController.CheckMoney(item))
        {
            if (inventoryController.CanAddItem())
            {
                playerMoneyController.BuyItem(item);

                // Add the item to the inventory
                inventoryController.AddItem(item);


                inventoryController.UpdateInventoryUI();
            }
            else
            {
                dialogBoxManager.ShowDialogBox("Inventory is full!");
            }
        }
        else
        {
            Debug.LogError("InventoryController reference not set.");
        }
    }
}