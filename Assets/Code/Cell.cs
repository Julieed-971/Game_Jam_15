

using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {

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


    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
        // if (PlayerManager.instance.IsCurrentlyBuilding() != CraftBuildingType.None) {
            if (LBlocked && PlayerManager.instance.currentWorld == World.Light
                || SBlocked && PlayerManager.instance.currentWorld == World.Shadow){
                HighlightBlockedCell();
            } else {
                HighlightValidCell();
            }
        // }
        Debug.Log("Mouse is over GameObject.");
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData) {
        UpdateColor();
        Debug.Log("Mouse is no longer on GameObject.");
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        // Do nothing or handle cell click if necessary
        if (PlayerManager.instance.IsCurrentlyBuilding() != BuildingType.None) {
            BuildOnIt(PlayerManager.instance.currentWorld);//TODO complete everything for building here


            BuildingDetailPanel.instance.Show(PlayerManager.instance.IsCurrentlyBuilding().ToString());
        } else {
            Debug.Log("Cell clicked but no building to build");
            BuildingDetailPanel.instance.Hide(); //TODO handle this, but only if we have a selected building already.
        }
        Debug.Log("Cell Clicked");
    }
}