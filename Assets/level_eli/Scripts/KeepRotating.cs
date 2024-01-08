using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotating : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust this value to change the rotation speed

    void Update()
    {
        // Rotate the object around its Y-axis
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
