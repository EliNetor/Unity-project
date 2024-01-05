using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    public Text countText;
    private int cans = 0;
    public AudioSource audioSource;
    public AudioClip collectableSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectables"))
        {
            CollectCan(other.gameObject);
            audioSource.PlayOneShot(collectableSound);
        }
    }

    private void CollectCan(GameObject item)
    {
        Destroy(item);
        cans++;
        UpdateText();
    }

    private void UpdateText()
    {
        if (countText != null)
        {
            countText.text = "Score: " + cans;
        }
    }

}
