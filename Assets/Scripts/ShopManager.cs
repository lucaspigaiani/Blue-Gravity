using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    public PlayerMoneyController playerMoneyController;
    public InventoryController inventoryController;

    private List<Skin> inventory = new List<Skin>(); // List to store bought items

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
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

                // Add the item to the inventory list
                inventory.Add(item);

                inventoryController.UpdateInventoryUI();
            }
            else
            {
                Debug.Log("Inventory is full!");
            }
        }
        else
        {
            Debug.LogError("InventoryController reference not set.");
        }
    }

  

    public void SellItem(Skin item)
    {
        playerMoneyController.SellItem(item);
    }


}