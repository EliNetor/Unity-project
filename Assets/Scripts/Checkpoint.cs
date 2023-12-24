using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that touched the checkpoint has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerController component from the player
            ToCheckpoint playerController = collision.gameObject.GetComponent<ToCheckpoint>();

            // Set the last checkpoint position to the position of this checkpoint
            playerController.SetLastCheckpoint(transform.position);
        }
    }
}
