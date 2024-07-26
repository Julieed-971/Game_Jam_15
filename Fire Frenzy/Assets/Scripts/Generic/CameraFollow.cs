using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject objectFollowed;

    public float minSpeed = 1.0f;
    public float maxSpeed = 5.0f;
    public float maxFollowDistance = 4.0f;
    public float stopDistance = 1.0f;
    public Vector2 deadZone;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.2f;
    public float decreaseFactor = 1.0f;

    bool isFollowing = false;

    void FixedUpdate() {
        if (objectFollowed == null) return;
        Vector3 position = this.transform.position;
        Vector3 followedPosition = objectFollowed.transform.position+new Vector3(0,-1,0);
        if (!isFollowing) {
            float distX = Mathf.Abs(followedPosition.x - position.x);
            float distY = Mathf.Abs(followedPosition.y - position.y);
            if (distX > deadZone.x || distY > deadZone.y) {
                isFollowing = true;
            }
            // if (Vector2.Distance(followedPosition, position) > deadZone) { // Old version
            //     isFollowing = true;
            // }
        }
        else {
            // float interpolation = speed * Time.fixedDeltaTime;
            float distance = Vector2.Distance(followedPosition, position);
            float adjustedSpeed = Mathf.Lerp(minSpeed, maxSpeed, (distance - stopDistance) / (maxFollowDistance - stopDistance));
            adjustedSpeed = Mathf.Clamp(adjustedSpeed, minSpeed, maxSpeed); // Ensure speed is within bounds

            float interpolation = adjustedSpeed * Time.fixedDeltaTime;
            position.y = Mathf.Lerp(position.y, followedPosition.y, interpolation);
            position.x = Mathf.Lerp(position.x, followedPosition.x, interpolation);

            this.transform.position = position;
            if (Vector2.Distance(followedPosition, position) < stopDistance) {
                isFollowing = false;
            }
        }
        if (shakeDuration > 0) {
            transform.position += Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.fixedDeltaTime * decreaseFactor;
        }
    }
}
