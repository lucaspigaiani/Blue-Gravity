using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // List of messages to display when the collectible is clicked
    public List<string> messages = new List<string>();

    // Maximum interaction range between player and item
    public float interactionRange = 3f;

    // References to panel controllers
    public PanelController shopManager;
    public PanelController inventoryController;

    // Reference to the dialog box manager
    private DialogBoxManager dialogBoxManager;

    // Reference to the player's transform
    private Transform playerTransform;

    // Start is called before the first frame update
    private void Start()
    {
        // Find and store a reference to the dialog box manager
        dialogBoxManager = GameObject.FindGameObjectWithTag("DialogBoxManager").GetComponent<DialogBoxManager>();

        // Find and store a reference to the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Called when the mouse button is clicked on the object
    private void OnMouseDown()
    {
        // Check if neither the shop nor inventory panel are active
        if (!shopManager.panel.activeInHierarchy && !inventoryController.panel.activeInHierarchy)
        {
            // Calculate the distance between the collectible and the player
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            // Check if the player is within interaction range
            if (distanceToPlayer <= interactionRange)
            {
                // Check if there are messages to display
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