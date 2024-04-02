using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBoxManager : MonoBehaviour
{
    // Reference to the UI elements
    public TextMeshProUGUI messageText;
    public GameObject dialogBox;

    // Duration parameters for fading in/out
    public float fadeInDuration = 0.5f;
    public float fadeOutDuration = 0.5f;
    public float displayTime = 3f;

    // Original and transparent colors
    private Color originalColor = Color.white;
    private Color transparentColor = new Color(1f, 1f, 1f, 0f);

    // Reference to the running coroutine
    private Coroutine currentCoroutine;

    // Start is called before the first frame update
    private void Start()
    {
        // Store the original color of the dialog box
        originalColor = dialogBox.GetComponent<Image>().color;

        // Hide the dialog box initially
        HideDialogBox();
    }

    // Display a message in the dialog box
    public void ShowDialogBox(string message)
    {
        // Stop any running coroutines before starting a new one
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        // Set the message text
        messageText.text = message;

        // Show the dialog box
        dialogBox.SetActive(true);

        // Start the fade in and out coroutine
        currentCoroutine = StartCoroutine(FadeInAndOut());
    }

    // Coroutine to fade in and out the dialog box
    private IEnumerator FadeInAndOut()
    {
        float elapsedTime = 0f;

        // Fade in
        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);

            // Fading the background color
            Color newBackgroundColor = originalColor;
            newBackgroundColor.a = alpha;
            dialogBox.GetComponent<Image>().color = newBackgroundColor;

            // Fading the text color
            Color newTextColor = messageText.color;
            newTextColor.a = alpha;
            messageText.color = newTextColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure both background and text are fully opaque
        dialogBox.GetComponent<Image>().color = originalColor;
        messageText.color = Color.white;

        // Wait for display time
        yield return new WaitForSeconds(displayTime);

        // Reset elapsed time for fade out
        elapsedTime = 0f;

        // Fade out
        while (elapsedTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration);

            // Fading the background color
            Color newBackgroundColor = originalColor;
            newBackgroundColor.a = alpha;
            dialogBox.GetComponent<Image>().color = newBackgroundColor;

            // Fading the text color
            Color newTextColor = messageText.color;
            newTextColor.a = alpha;
            messageText.color = newTextColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure both background and text are fully transparent
        dialogBox.GetComponent<Image>().color = transparentColor;
        messageText.color = transparentColor;

        // Hide the dialog box after fading out
        HideDialogBox();
    }

    // Hide the dialog box
    public void HideDialogBox()
    {
        dialogBox.SetActive(false);
    }
}