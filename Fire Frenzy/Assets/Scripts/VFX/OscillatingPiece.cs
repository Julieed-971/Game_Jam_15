using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingPiece : MonoBehaviour {
    public float amplitude = 0.02f; // The height of the oscillation
    public float frequency = 3f; // How fast it oscillates
    public float offset = 0.01f; // How high it is offset
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }
    void OnEnable()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        Vector3 tempPos = startPosition;
        tempPos.y += Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude + offset;

        transform.position = tempPos;
    }
}
