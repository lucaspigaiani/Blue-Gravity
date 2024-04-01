using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Reference to the panel GameObject 

    // Method to open the panel
    public void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf); // Toggle the active state of the panel
        }
    }
}