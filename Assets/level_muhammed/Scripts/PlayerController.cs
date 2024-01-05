using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;
    public bool Grounded
    {
        get { return grounded; }
    }
    public bool space;
    public float animspeed = 0.0185f;

    private bool isJumping = false;
    private float jumpTime = 0f;
    public float minJumpForce = 8f; 
    public float maxJumpForce = 20f; 
    public float maxHoldTime = 2f;
    private GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        IsGrounded();
        Jump();
        Move();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded && !isJumping)
        {
            isJumping = true;
            jumpTime = 0f;
            space = true;
            anim.SetBool("space", space);
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            jumpTime += Time.deltaTime;
            jumpTime = Mathf.Clamp(jumpTime, 0f, maxHoldTime);

        }
        if ((Input.GetKeyUp(KeyCode.Space) || jumpTime >= maxHoldTime) && isJumping)
        {
            float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, jumpTime / maxHoldTime);
            Vector3 upwardForce = Vector3.up * jumpForce;
            Vector3 forwardForce = transform.forward *  5f; 
            rb.AddForce(upwardForce + forwardForce, ForceMode.Impulse);

            isJumping = false;
            space = false;
            anim.SetBool("space", space);
            audioSource.PlayOneShot(jumpSound);
        }
    }


    private void IsGrounded()
    {
        if(Physics.CheckSphere(transform.position + Vector3.down, 0.3f, layerMask))
        {
            grounded = true;
        } else
        {
            grounded = false;
            
        }
        anim.SetBool("jump", !grounded);
    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        if (!space && grounded && !gameManager.IsGamePaused())
        {
            Vector3 movement = transform.forward * verticalAxis + transform.right * horizontalAxis;
            movement.Normalize();
            transform.position += movement * animspeed;
        }

        anim.SetFloat("vertical", verticalAxis);
        anim.SetFloat("horizontal", horizontalAxis);
    }
}
