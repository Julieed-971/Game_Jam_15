using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateObjectsAfterDelay : MonoBehaviour
{
    public List<GameObject> objectsToActivate;
    public float activationDelay;
    public AudioClip soundToPlay;

    void Start() {
        foreach (var obj in objectsToActivate) {
            if (obj != null) {
                obj.SetActive(false); // Ensure all objects are initially inactive
            }
        }
        StartCoroutine(ActivateAfterDelay());
    }

    IEnumerator ActivateAfterDelay() {
        yield return new WaitForSeconds(activationDelay);
        foreach (var obj in objectsToActivate) {
            if (obj != null) {
                obj.SetActive(true);
            }
            if (soundToPlay != null) {
                SoundManager.instance.PlayClip(soundToPlay);
            }
        }
    }
}
