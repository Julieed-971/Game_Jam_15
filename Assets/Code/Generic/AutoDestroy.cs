
using UnityEngine;
public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 2.5f;

    void Start() {
        Destroy(gameObject, lifetime);
    }
}
