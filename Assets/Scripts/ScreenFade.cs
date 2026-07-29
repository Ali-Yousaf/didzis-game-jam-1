using System.Collections;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    public static ScreenFade Instance;

    [SerializeField] private CanvasGroup canvasGroup;

    private Coroutine fadeCoroutine;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        canvasGroup.alpha = 0f;
    }

    public void Fade(float duration)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeRoutine(duration));
    }

    private IEnumerator FadeRoutine(float duration)
    {
        // Fade to black
        yield return FadeCanvas(0f, 1f, duration);

        // Optional: stay black for one frame
        yield return null;

        // Fade back in
        yield return FadeCanvas(1f, 0f, duration);

        fadeCoroutine = null;
    }

    private IEnumerator FadeCanvas(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);

            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }
}