using UnityEngine.UI;
using UnityEngine;

public class OscillatingAlpha : MonoBehaviour
{
    public float oscillationSpeed = 1.0f;
    public float minAlpha = 0.5f;
    public float maxAlpha = 1.0f;

    private SpriteRenderer spriteRenderer;
    Image image;
    TMPro.TextMeshProUGUI text; 

    void Start() {
        image = GetComponent<Image>();
        text = GetComponent<TMPro.TextMeshProUGUI>();   
        if (image == null && text == null)
            spriteRenderer = image.GetComponent<SpriteRenderer>();
        
    }

    void Update() {
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, (Mathf.Sin(Time.time * oscillationSpeed) + 1) / 2);
        if (image == null && text == null){
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        } else if (text == null) {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        } else {
            Color color = text.color;
            color.a = alpha;
            text.color = color;
        }
    }
}
