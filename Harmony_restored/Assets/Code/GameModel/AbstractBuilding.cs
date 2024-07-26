using UnityEngine;

public abstract class AbstractBuilding : MonoBehaviour {
    public BuildingType type;
    public World world;
    public int width;
    public int height;
    public void Start() {
        if (width == 0 || height == 0) {
            Debug.LogError("Craft building " + type + " has no width or height");
        }
    }
}