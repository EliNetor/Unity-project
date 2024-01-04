using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCollectables : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectables"))
        {
            CollectItem(other.gameObject);
        }
    }

    private void CollectItem(GameObject item)
    {
        // You can add additional logic here for special effects, sound, etc.
        Destroy(item);  // Assuming you want to remove the collected item from the scene.

        // Update the score and the score text
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

}
