using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInXScript : MonoBehaviour {
    // Start is called before the first frame update
    public float fadeOutAfter = 3f;
    public FadeInOut fadeInOut;
    void Start() {
        StartCoroutine(FadeOutAfter());
    }

    IEnumerator FadeOutAfter() {
        yield return new WaitForSeconds(fadeOutAfter);
        fadeInOut.FadeOut("MainMenu");
    }
}
