using UnityEngine;

public class RotatingUI : MonoBehaviour
{
    public float rotationSpeed = 100f; // Rotation speed in degrees per second

    void Update()     {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
