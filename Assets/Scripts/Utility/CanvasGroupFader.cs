using System.Collections;
using UnityEngine;

public class CanvasGroupFader : MonoBehaviour {

    public float defaultFadeTime = 1f;
    public bool startTransparent;
    public bool fadeInOnStart;

    CanvasGroup canvasGroup;
    bool fading;
    bool transparent;
    float fadeTime;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        fading = false;
        transparent = startTransparent;
    }

    void Start() {
        canvasGroup.alpha = transparent ? 0 : 1;
        if (fadeInOnStart) RequestFadeIn();
    }

    public bool IsIdle() {
        return !fading;
    }

    public void RequestFadeIn(bool useUnscaledTime = false) {
        RequestFadeIn(defaultFadeTime, useUnscaledTime);
    }

    public void RequestFadeIn(float fadeTime, bool useUnscaledTime=false) {
        if (!fading && transparent) {
            this.fadeTime = fadeTime;
            StartCoroutine(FadeRoutine(0, 1, useUnscaledTime));
        }
        else
            Debug.LogWarning("[" + this + "]RequestFadeIn: Cannot execute operation at the moment.");
    }

    public void RequestFadeOut(bool useUnscaledTime = false) {
        RequestFadeOut(defaultFadeTime, useUnscaledTime);
    }

    public void RequestFadeOut(float fadeTime, bool useUnscaledTime = false) {
        if (!fading && !transparent) {
            this.fadeTime = fadeTime;
            StartCoroutine(FadeRoutine(1, 0, useUnscaledTime));
        }
        else
            Debug.LogWarning("[" + this + "]RequestFadeOut: Cannot execute operation at the moment.");
    }

    IEnumerator FadeRoutine(float startAlpha, float finalAlpha, bool useUnscaledTime) {
        fading = true;
        canvasGroup.alpha = startAlpha;
        float elapsedTime = 0;
        while (elapsedTime < fadeTime) {
            yield return null;
            elapsedTime += useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, finalAlpha, elapsedTime / fadeTime);
        }
        canvasGroup.alpha = finalAlpha;
        fading = false;
        transparent = finalAlpha == 0;
    }
}
