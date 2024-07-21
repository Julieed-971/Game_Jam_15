using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlickeringEffect : MonoBehaviour {
    public float flickerInterval = 0.5f;
    private Image imageComponent;
    private bool isFlickering;

    void Start() {
        imageComponent = GetComponent<Image>();
    }

    void OnEnable() {
        imageComponent = GetComponent<Image>();
        isFlickering = true;
        imageComponent.enabled = false;
        StartCoroutine(Flicker());
    }

    // void OnDisable() {
    //     isFlickering = false;
    //     if (imageComponent != null) {
    //         imageComponent.enabled = true; // Ensure the image is visible when the object is re-enabled.
    //     }
    // }

    IEnumerator Flicker() {
        while (isFlickering) {
            imageComponent.enabled = !imageComponent.enabled;
            yield return new WaitForSeconds(flickerInterval);
        }
    }
}
