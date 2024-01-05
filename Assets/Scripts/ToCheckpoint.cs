using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCheckpoint : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 lastCheckpointPosition;

    void Start()
    {
        // Store the initial position as the starting checkpoint
        initialPosition = transform.position;
        lastCheckpointPosition = initialPosition;
    }

    void Update()
    {
        // Check if the player presses the 'F' key
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Teleport the player to the last checkpoint position
            transform.position = lastCheckpointPosition;
        }
    }

    // Function to set the last checkpoint position
    public void SetLastCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpointPosition = checkpointPosition;
    }
}
