using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public string npcName = "NPC"; // Name of the NPC (for identification)
    public string[] messages; // Array of messages to choose from

    private DialogBoxManager dialogBoxManager;

    public PanelController shopManager;
    public PanelController inventoryController;
    public float displayTime = 3f; // Time in seconds to display the dialog box
    private bool isDialogActive = false;


    private void Start()
    {
        dialogBoxManager = GameObject.FindGameObjectWithTag("DialogBoxManager").GetComponent<DialogBoxManager>();
    }

    private void OnMouseDown()
    {
        if (!isDialogActive && dialogBoxManager != null && messages.Length > 0 && !shopManager.panel.activeInHierarchy && !inventoryController.panel.activeInHierarchy)
        {
            int randomIndex = Random.Range(0, messages.Length); // Generate a random index
            string randomMessage = messages[randomIndex]; // Get a random message from the array
            dialogBoxManager.ShowDialogBox(randomMessage);
            isDialogActive = true;
            shopManager.TogglePanel();
            Invoke(nameof(ResetDialogState), displayTime);
        }
    }

    private void ResetDialogState()
    {
        isDialogActive = false;
    }
}