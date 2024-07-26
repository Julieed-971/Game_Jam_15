using System;
using UnityEngine;

public class TimedExistence : MonoBehaviour {
    public int turnsRemaining; // Number of turns this object will remain active
    public Action onTurnsEnd; // Action to perform when turns run out

    void Start(){
        onTurnsEnd ??= DefaultEndAction;
    }
    
    public void ProgressTurn() {
        turnsRemaining--;
        if (turnsRemaining <= 0) {
            onTurnsEnd?.Invoke(); // Perform the action if the counter has reached 0
            Destroy(gameObject); // Destroy this object or disable it as needed
        }
    }

    private void DefaultEndAction() {
        Debug.Log($"{gameObject.name} has run out of turns and will be removed.");
    }

    // You can set a custom action from another class
    public void SetCustomEndAction(Action customAction) {
        onTurnsEnd = customAction;
    }
}
