using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public ResourceType type;
    // allow on click and maintain to collect
    void OnMouseDown(){
        Collect();
    }
    void OnMouseUp(){
        FillCollect.instance.CancelFill();
    }
    void Collect(){
        FillCollect.instance.StartFill(type);
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
