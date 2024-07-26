using System.Collections;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour {
    public float typingSpeed = 0.05f;
    [TextArea(3,10)]
    public string fullText;
    private string currentText = "";
    private TextMeshProUGUI textComponent;

    void Start() {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public IEnumerator TypeText() {
        currentText = "";
        foreach (char letter in fullText.ToCharArray()) {
            currentText += letter;
            textComponent.text = currentText;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }
}
