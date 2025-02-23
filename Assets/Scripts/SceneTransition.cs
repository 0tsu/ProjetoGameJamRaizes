using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] CanvasGroup fadeCanvasGroup;
    [SerializeField] float fadeDuration;

    void Start()
    {
        fadeCanvasGroup.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string scaneName)
    {
        StartCoroutine(FadeOut(scaneName));
    }

    IEnumerator FadeIn()
    {
        fadeCanvasGroup.alpha = 1;
        while (fadeCanvasGroup.alpha > 0)
        {
            fadeCanvasGroup.alpha -= Time.deltaTime / fadeDuration;
            yield return null;
        }
    }

    IEnumerator FadeOut(string scaneName)
    {
        fadeCanvasGroup.alpha = 0;

        while (fadeCanvasGroup.alpha < 1)
        {
            fadeCanvasGroup.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }

        SceneManager.LoadScene(scaneName);
    }
}
