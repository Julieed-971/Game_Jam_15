
using UnityEngine;

public class CraftBuilding : MonoBehaviour {

    public CraftBuildingType type;
    public World world;
    public Recipe[] recipes;
    public int width;
    public int height;
    public void Start() {
        if (width == 0 || height == 0) {
            Debug.LogError("Craft building " + type + " has no width or height");
        }
    }
}