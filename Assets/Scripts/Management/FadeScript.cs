using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    public CanvasGroup canvasGroup; // Drag your Canvas Group here in the inspector
    public Canvas canvas;
    public SceneTransition _sceneTransition;
    public float fadeDuration = 1f;
    public bool fade = false;
    public PauseController pauseController;

    private void Start()
    {
        canvas.enabled = false;
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

    public void Fade()
    {
        StartCoroutine(FadeInOutSequence());
    }

    public IEnumerator FadeInOutSequence()
    {
        canvas.enabled = true;
        // Play FadeIn
        FadeIn();
        yield return new WaitForSeconds(1f); // Wait for the fade-in to complete
        pauseController.menuEnableController(true);
        _sceneTransition.SwitchScene();
        yield return new WaitForSeconds(1f);
        pauseController.menuEnableController(false);
        yield return new WaitForSeconds(1f); // You can change this value for a longer or shorter wait before fade-out
        FadeOut();
        yield return new WaitForSeconds(1f); // You can change this value for a longer or shorter wait before fade-out
        canvas.enabled = false;
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
