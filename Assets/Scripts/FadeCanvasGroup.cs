using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeCanvasGroup : MonoBehaviour
{
    [SerializeField] private float startAlpha;
    [SerializeField] private float endAlpha;
    [SerializeField] private float duration;
    CanvasGroup canvasGroup;

    [SerializeField] private bool playOnStart;

    [SerializeField] private bool loop;

    // Start is called before the first frame update
    void Start()
    {
        if(playOnStart)
            ExecuteCrossfade(startAlpha, endAlpha, duration);
    }

    public void ExecuteCrossfade(float startAlpha, float endAlpha, float duration)
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = startAlpha;

        StartCoroutine(CrossfadeAlpha(startAlpha, endAlpha, duration));
    }

    public void ExecuteCrossfade(float endAlpha, float duration)
    {
        canvasGroup = GetComponent<CanvasGroup>();
        startAlpha = canvasGroup.alpha;

        StartCoroutine(CrossfadeAlpha(canvasGroup.alpha, endAlpha, duration));
    }

    public void ExecuteCrossfade()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(CrossfadeAlpha(startAlpha, endAlpha, duration));
    }


    IEnumerator CrossfadeAlpha(float startAlpha, float endAlpha, float duration)
    {
        float timer = 0f;
        while(timer < duration)
        {
            timer += Time.deltaTime;

            float t = Mathf.Clamp01(Mathf.InverseLerp(0f, duration, timer));
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);

            yield return null;
        }

        if (loop)
        {
            StartCoroutine(CrossfadeAlpha(endAlpha, startAlpha, duration));
            yield break;
        }

        canvasGroup.alpha = endAlpha;
    }
}
