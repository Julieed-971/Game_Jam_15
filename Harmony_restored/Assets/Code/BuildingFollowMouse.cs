using UnityEngine;

public class BuildingFollowMouse : MonoBehaviour {
    
    bool isFollowing = true;
    
    void Update() {
        if (isFollowing){
            transform.position = Input.mousePosition;
        }
    }
}
