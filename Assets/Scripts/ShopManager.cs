using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance; // Static reference to the shop manager instance
    public PlayerMoneyController playerMoneyController; // Reference to the player's money controller
    public InventoryController inventoryController; // Reference to the inventory controller

    private DialogBoxManager dialogBoxManager; // Reference to the dialog box manager

    public Skin[] storeItems; // Array of store items
    public GameObject shopButtonPrefab; // Prefab for the shop button
    public GameObject storeContent; // Reference to the store content panel

    // Singleton pattern to ensure only one instance of ShopManager exists
    private void Awake()
    {
        Instance = this;
    }

    // Initialization
    private void Start()
    {
        // Find and store references to other managers
        dialogBoxManager = GameObject.FindGameObjectWithTag("DialogBoxManager").GetComponent<DialogBoxManager>();

        // Initialize the shop
        Initialize();
    }

    // Initialize the shop by instantiating shop buttons for each store item
    private void Initialize()
    {
        for (int i = 0; i < storeItems.Length; i++)
        {
            // Instantiate the shop button prefab and set its parent to the store content panel
            GameObject buttonGO = Instantiate(shopButtonPrefab, storeContent.transform);

            // Get the ShopButton component from the instantiated GameObject
            ShopButton newItem = buttonGO.GetComponent<ShopButton>();

            // Set the item for the ShopButton
            newItem.item = storeItems[i];
        }
    }

    // Method to handle buying an item from the shop
    public void BuyItem(Skin item)
    {
        if (inventoryController != null)
        {
            // Check if the player has enough money to buy the item
            if (playerMoneyController.CheckMoney(item))
            {
                // Check if the inventory has space to add the item
                if (inventoryController.CanAddItem())
                {
                    // Deduct the item price from the player's money
                    playerMoneyController.BuyItem(item);

                    // Add the item to the inventory
                    inventoryController.AddItem(item);

                    // Update the inventory UI
                    inventoryController.UpdateInventoryUI();
                }
                else
                {
                    // Show a message if the inventory is full
                    dialogBoxManager.ShowDialogBox("Inventory is full!");
                }
            }
            else
            {
                // Show a message if the player has insufficient funds
                dialogBoxManager.ShowDialogBox("Insufficient funds!");
            }
        }
    }
}