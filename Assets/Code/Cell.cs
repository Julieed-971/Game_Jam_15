

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
    public GroundGridGenerator groundGrid;
    bool colored = false;
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }
    // Color the cell based on the light level
    public void UpdateColor(){
        spriteRenderer.color = lightColors[lightLevel+5];
    }
    public bool HighlightCell(){
        colored = true;
        if (LBlocked && PlayerManager.instance.currentWorld == World.Light
            || SBlocked && PlayerManager.instance.currentWorld == World.Shadow){
            HighlightBlockedCell();
            return false;
        } else {
            HighlightValidCell();
            return true;
        }
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
        AbstractBuilding currentBuilding = PlayerManager.instance.IsCurrentlyBuilding();

        if (currentBuilding != null && currentBuilding.type != BuildingType.None) {
            groundGrid.HighlightCells(coordinates, currentBuilding.width, currentBuilding.height);
            // if (LBlocked && PlayerManager.instance.currentWorld == World.Light
            //     || SBlocked && PlayerManager.instance.currentWorld == World.Shadow){
            //     HighlightBlockedCell();
            // } else {
            //     HighlightValidCell();
            // }
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData) {
        // Reset the color of the cell
        groundGrid.ClearColors(coordinates);
    }
    public void ClearCell(){
        if (colored){
            colored = false;
            UpdateColor();
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        AbstractBuilding currentBuilding = PlayerManager.instance.IsCurrentlyBuilding();
        // Do nothing or handle cell click if necessary
        if (currentBuilding != null && currentBuilding.type != BuildingType.None) {
            BuildOnIt(PlayerManager.instance.currentWorld);//TODO complete everything for building here


            BuildingDetailPanel.instance.Show(PlayerManager.instance.IsCurrentlyBuilding().ToString());
        } else {
            Debug.Log("Cell clicked but no building to build");
            BuildingDetailPanel.instance.Hide(); //TODO handle this, but only if we have a selected building already.
        }
        Debug.Log("Cell Clicked");
    }
}