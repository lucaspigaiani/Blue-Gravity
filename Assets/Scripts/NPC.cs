using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName = "NPC"; // Name of the NPC (for identification)
    public string[] messages; // Array of messages to choose from

    private DialogBoxManager dialogBoxManager;
    private Transform playerTransform; // Reference to the player's transform
    public float interactionRange = 3f; // Maximum interaction range between player and NPC

    public PanelController shopManager;
    public PanelController inventoryController;
    public float displayTime = 3f; // Time in seconds to display the dialog box
    private bool isDialogActive = false;

    private void Start()
    {
        // Find and store a reference to the dialog box manager
        dialogBoxManager = GameObject.FindGameObjectWithTag("DialogBoxManager").GetComponent<DialogBoxManager>();
        // Find and store a reference to the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnMouseDown()
    {
        // Calculate the distance between the NPC and the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        // Check if the player is within interaction range
        if (distanceToPlayer <= interactionRange)
        {
            // Check if the dialog box is not already active, there are messages, and neither the shop nor inventory panel are active
            if (!isDialogActive && dialogBoxManager != null && messages.Length > 0 && !shopManager.panel.activeInHierarchy && !inventoryController.panel.activeInHierarchy)
            {
                // Generate a random index to select a message from the array
                int randomIndex = Random.Range(0, messages.Length);
                // Get a random message from the array
                string randomMessage = messages[randomIndex];
                // Show the random message in the dialog box
                dialogBoxManager.ShowDialogBox(randomMessage);
                // Set the dialog box as active
                isDialogActive = true;
                // Toggle the shop panel
                shopManager.TogglePanel();
                // Reset the dialog state after a delay
                Invoke(nameof(ResetDialogState), displayTime);
            }
        }
    }

    // Reset the dialog state to inactive
    private void ResetDialogState()
    {
        isDialogActive = false;
    }
}