using System.Collections;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 2f;
    private bool isFading = false;

    public void StartFade()
    {
        if (!isFading)
            StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        isFading = true;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}

