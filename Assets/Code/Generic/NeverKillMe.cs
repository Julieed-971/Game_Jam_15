using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverKillMe : MonoBehaviour { 
    // Start is called before the first frame update
    void Start() {        
        DontDestroyOnLoad(this);    
    }
    void Awake() {
        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1) {
            Destroy(gameObject);
        }
    }
}
