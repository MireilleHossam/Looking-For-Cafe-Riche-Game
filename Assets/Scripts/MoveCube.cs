using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    public float distance = 5f; // Distance to move back and forth

    private Vector3 startPosition; // To store the initial position VECTOR 3 (x,y,z)

    void Start()
    {
        // Store the initial position of the cube
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position using a sine wave
        float offset = Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
    }
}