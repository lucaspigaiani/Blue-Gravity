using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{  
    // Maximum capacity of the inventory
    public int inventoryCapacity = 10;

    // List to store items in the inventory
    public List<Skin> inventory = new List<Skin>();

    // Reference to the inventory panel
    public GameObject inventoryPanel;

    // Prefab for inventory buttons
    public GameObject inventoryButtonPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        // Update the inventory UI
        UpdateInventoryUI();
    }

    // Check if an item can be added to the inventory
    public bool CanAddItem()
    {
        return inventory.Count < inventoryCapacity;
    }

    // Add an item to the inventory
    public void AddItem(Skin item)
    {
        inventory.Add(item);
    }

    // Remove an item from the inventory
    public void RemoveItem(Skin item)
    {
        inventory.Remove(item);
    }

    // Update the inventory UI
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
