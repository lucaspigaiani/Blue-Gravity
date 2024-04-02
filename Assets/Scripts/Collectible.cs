using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public List<string> messages = new List<string>(); // List of messages to display when the collectible is clicked
    public float interactionRange = 3f; // Maximum interaction range between player and item
    public PanelController shopManager;
    public PanelController inventoryController;

    private DialogBoxManager dialogBoxManager; // Reference to the dialog box manager
    private Transform playerTransform; // Reference to the player's transform


    private void Start()
    {
        // Find and store a reference to the dialog box manager
        dialogBoxManager = GameObject.FindGameObjectWithTag("DialogBoxManager").GetComponent<DialogBoxManager>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnMouseDown()
    {
        if (!shopManager.panel.activeInHierarchy && !inventoryController.panel.activeInHierarchy)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer <= interactionRange)
            {
                if (messages.Count > 0)
                {
                    // Select a random message from the list
                    string randomMessage = messages[Random.Range(0, messages.Count)];

                    // Show the random message in the dialog box
                    dialogBoxManager.ShowDialogBox(randomMessage);
                }
            }
        }
        
    }
}