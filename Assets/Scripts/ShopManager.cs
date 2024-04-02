using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    public PlayerMoneyController playerMoneyController;
    public InventoryController inventoryController;

    private DialogBoxManager dialogBoxManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        dialogBoxManager = GameObject.FindGameObjectWithTag("DialogBoxManager").GetComponent<DialogBoxManager>();
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