using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Reference to the panel GameObject 

    // Method to open/close the panel
    public void TogglePanel()
    {
        // Check if the panel reference is not null
        if (panel != null)
        {
            // Toggle the active state of the panel
            panel.SetActive(!panel.activeSelf);
        }
    }
}