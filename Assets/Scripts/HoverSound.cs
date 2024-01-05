using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HoverSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip hoverSound;
    private bool canPlay;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = hoverSound;
        canPlay = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (canPlay)
        {
            audioSource.Play();
            canPlay = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canPlay = true;
    }
}
