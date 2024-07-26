using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeInOut : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.5f;

    private void Start() {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn() {
        if (!fadeImage.IsActive()) {
            fadeImage.gameObject.SetActive(true);
        }
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;
            color.a = 1 - (elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0;
        fadeImage.color = color;
        fadeImage.gameObject.SetActive(false); // Deactivate the image after fade in
    }

    public void  FadeOut(string sceneToLoad) {
        StopAllCoroutines();
        StartCoroutine(FadeOutCoroutine(sceneToLoad));
    }

    IEnumerator FadeOutCoroutine(string sceneToLoad)
    {
        fadeImage.gameObject.SetActive(true);
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = elapsedTime / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1;
        fadeImage.color = color;

        SceneManager.LoadScene(sceneToLoad); // Load the next scene
    }
}
