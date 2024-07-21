


using UnityEngine;

public class PlayerManager: Singleton<PlayerManager> {
    public World currentWorld;

    public GameObject background;
    public Sprite shadowBackgroundSprite;
    public Sprite lightBackgroundSprite;
    public TheWorld theWorld;
    public BuildingType buildingThisBuilding;

    void Start(){
        currentWorld = World.Light;
        background.GetComponent<SpriteRenderer>().sprite = lightBackgroundSprite;
        buildingThisBuilding = BuildingType.None;
        theWorld.SwitchWorld(currentWorld);
    }
    void Update(){
        SwitchWorld();
    }


    public void SwitchWorld(){
        // listen to space key to change world
        if (Input.GetKeyDown(KeyCode.Space)){
            if (currentWorld == World.Light){
                currentWorld = World.Shadow;
                background.GetComponent<SpriteRenderer>().sprite = shadowBackgroundSprite;
            } else {
                currentWorld = World.Light;
                background.GetComponent<SpriteRenderer>().sprite = lightBackgroundSprite;
            }
            Debug.Log("Switched to " + currentWorld);
            theWorld.SwitchWorld(currentWorld);
            FillCollect.instance.CancelFill();
        }
    }

    public void AddResource(ResourceType type){
        Debug.Log("Added resource " + type);
    }

    public BuildingType IsCurrentlyBuilding(){
        return buildingThisBuilding;
    }
}