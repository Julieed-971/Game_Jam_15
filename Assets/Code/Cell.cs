

using UnityEngine;

public class Cell : MonoBehaviour {

    public Vector2Int coordinates;
    // 10 colors for light and shadow
    public Color[] lightColors;
    // defines the current int representing light and shadow, and update the color accordingly
    public int lightLevel = 0;
    public bool LBlocked = false;
    public bool SBlocked = false;
    public SpriteRenderer spriteRenderer;
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }
    // Color the cell based on the light level
    public void UpdateColor(){
        spriteRenderer.color = lightColors[lightLevel+5];
    }
    public void HighlightBlockedCell(){
        spriteRenderer.color = Color.red;
    }
    public void HighlightValidCell(){
        spriteRenderer.color = Color.green;
    }
    public void BuildOnIt(World world){
        if (world == World.Light){
            LBlocked = true;
        } else {
            SBlocked = true;
        }
    }

    void OnMouseOver() {
        if (LBlocked && PlayerManager.instance.currentWorld == World.Light
            || SBlocked && PlayerManager.instance.currentWorld == World.Shadow){
            HighlightBlockedCell();
        } else {
            HighlightValidCell();
        }
        Debug.Log("Mouse is over GameObject.");
    }
    void OnMouseExit() {
        UpdateColor();
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}