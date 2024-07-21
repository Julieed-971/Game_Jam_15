using UnityEngine;

public class Recipe : MonoBehaviour {

    public Resource resource1In;
    public int resource1InAmount;
    public Resource resource2In;
    public int resource2InAmount;
    public Resource resource3In;
    public int resource3InAmount;
    public Resource resourceOut;
    
    public bool known = false;
    
    public void Start() {
    }
    
    public bool IsValid(Resource resource1, int resource1Amount, Resource resource2, int resource2Amount, Resource resource3, int resource3Amount) {
        if (resource1In == resource1 && resource1InAmount == resource1Amount) {
            if (resource2In == resource2 && resource2InAmount == resource2Amount) {
                if (resource3In == resource3 && resource3InAmount == resource3Amount) {
                    return true;
                }
            }
        }
        return false;
    }
    public bool IsValid(Resource resource1, int resource1Amount, Resource resource2, int resource2Amount) {
        if (resource1In == resource1 && resource1InAmount == resource1Amount) {
            if (resource2In == resource2 && resource2InAmount == resource2Amount) {
                return true;
            }
        }
        return false;
    }
}