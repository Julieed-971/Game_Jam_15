using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOutAndDestroy : MonoBehaviour
{
    public Image imageToFade;
    public float fadeDuration = 1f;

    void OnEnable()
    {
        StartCoroutine(FadeToTransparentAndDestroy());
    }

    IEnumerator FadeToTransparentAndDestroy()
    {
        float elapsedTime = 0;
        Color startColor = imageToFade.color;
        startColor.a = 1;
        imageToFade.color = startColor;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            imageToFade.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            yield return null;
        }

        Destroy(gameObject);
    }
}
