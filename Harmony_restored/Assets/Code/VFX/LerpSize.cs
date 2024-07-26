using UnityEngine;

public class LerpSize : MonoBehaviour {
    public RectTransform targetRectTransform;
    public Vector2 targetSize;
    public float lerpDuration = 1f;
    private bool isLerping = false;
    private bool isExpanding = true;
    private float timeStartedLerping;

    void Start() {
        targetRectTransform.sizeDelta = Vector2.zero;
        StartExpanding();
    }

    void Update() {
        if (isLerping) {
            float timeSinceStarted = Time.time - timeStartedLerping;
            float percentageComplete = timeSinceStarted / lerpDuration;

            Vector2 currentSize = isExpanding ? 
                Vector2.Lerp(Vector2.zero, targetSize, percentageComplete) : 
                Vector2.Lerp(targetSize, Vector2.zero, percentageComplete);

            targetRectTransform.sizeDelta = currentSize;

            if (percentageComplete >= 1.0f) {
                isLerping = false;
            }
        }
    }

    public void StartExpanding()
    {
        isExpanding = true;
        StartLerping();
    }

    public void StartCollapsing()
    {
        isExpanding = false;
        StartLerping();
    }

    private void StartLerping()
    {
        isLerping = true;
        timeStartedLerping = Time.time;
    }
}
