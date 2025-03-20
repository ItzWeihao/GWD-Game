using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    public CanvasGroup canvasGroup; // Drag your Canvas Group here in the inspector
    public float fadeDuration = 1f;
    public bool fade = false;

    private void Start()
    {
        
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0f, 1f)); // Fade in (from 0 to 1)
        fade = true;
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(1f, 0f)); // Fade out (from 1 to 0)
        fade = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Start the FadeIn and FadeOut sequence when 'E' is pressed
            StartCoroutine(FadeInOutSequence());
        }
    }

    private IEnumerator FadeInOutSequence()
    {
        // Play FadeIn
        FadeIn();
        yield return new WaitForSeconds(fadeDuration); // Wait for the fade-in to complete

        // After 1 second (or fadeDuration), play FadeOut
        yield return new WaitForSeconds(1f); // You can change this value for a longer or shorter wait before fade-out
        FadeOut();
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float timeElapsed = 0f;

        // Set the initial alpha
        canvasGroup.alpha = startAlpha;

        while (timeElapsed < fadeDuration)
        {
            // Interpolate alpha value over time
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the final alpha is set correctly
        canvasGroup.alpha = endAlpha;
    }
}
