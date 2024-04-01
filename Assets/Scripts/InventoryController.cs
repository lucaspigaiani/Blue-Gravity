using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{

    public int inventoryCapacity = 10; // Maximum capacity of the inventory
    private List<Skin> inventory = new List<Skin>(); // List to store items in the inventory

    public GameObject inventoryPanel; // Reference to the inventory panel
    public GameObject inventoryButtonPrefab; // Prefab for inventory buttons

    public bool CanAddItem()
    {
        return inventory.Count < inventoryCapacity;
    }

    public void AddItem(Skin item)
    {
        inventory.Add(item);
    }

    public void UpdateInventoryUI()
    {
        // Clear the inventory panel
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate inventory buttons for each item in the inventory
        foreach (var item in inventory)
        {
            GameObject buttonGO = Instantiate(inventoryButtonPrefab, inventoryPanel.transform);
            InventoryButton button = buttonGO.GetComponent<InventoryButton>();
            button.Initialize(item);
        }
    }
}
