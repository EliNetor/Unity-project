using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapse : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody rb;
    public Animator anim;
    private bool wasFalling = false;
    public AudioSource audioSource; 
    public AudioClip fallSound;
    public AudioClip fallingSound;
    private bool fallingSoundPlayed = false;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool isPlayerGrounded = playerController.Grounded;
        bool isFalling = (rb.velocity.y < -19f);
        
        if (isFalling && !isPlayerGrounded)
        {
            
            anim.SetBool("falling", true);
            if (!fallingSoundPlayed)
            {
                audioSource.PlayOneShot(fallingSound);
            }
            fallingSoundPlayed = true;

        } else
        {
            anim.SetBool("falling", false);
            fallingSoundPlayed = false;
        }

        wasFalling = isFalling;

        if (wasFalling && isPlayerGrounded) 
        {
            audioSource.Stop();
            anim.SetBool("collapse", true);
            audioSource.PlayOneShot(fallSound);
        } 
        else 
        {
            if ((Input.anyKey) && isPlayerGrounded )
            {
                anim.SetBool("collapse", wasFalling);
            }
        }
         
    }
}