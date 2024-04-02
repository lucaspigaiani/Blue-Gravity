using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBoxManager : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public GameObject dialogBox;

    public float fadeInDuration = 0.5f;
    public float fadeOutDuration = 0.5f;
    public float displayTime = 3f;

    private Color originalColor = Color.white;
    private Color transparentColor = new Color(1f, 1f, 1f, 0f);

    private Coroutine currentCoroutine;

    private void Start()
    {
        originalColor = dialogBox.GetComponent<Image>().color;
        HideDialogBox();
    }

    public void ShowDialogBox(string message)
    {
        // Stop any running coroutines before starting a new one
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        messageText.text = message;
        dialogBox.SetActive(true);
        currentCoroutine = StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        float elapsedTime = 0f;

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

        yield return new WaitForSeconds(displayTime);

        elapsedTime = 0f;

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

    public void HideDialogBox()
    {
        dialogBox.SetActive(false);
    }
}