using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpforward : MonoBehaviour
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
    public AudioSource audioSource;
    public AudioClip jumpSound;
    private bool stopSlide = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        IsGrounded();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded && !isJumping)
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
            Vector3 upwardForce = Vector3.forward * jumpForce;
            Vector3 forwardForce = transform.up * 7.5f;
            rb.AddForce(upwardForce + forwardForce, ForceMode.Impulse);

            isJumping = false;
            space = false;
            anim.SetBool("space", space);
            audioSource.PlayOneShot(jumpSound);
        }
    }


    private void IsGrounded()
    {
        if (Physics.CheckSphere(transform.position + Vector3.down, 0.3f, layerMask))
        {
            grounded = true;
            if(stopSlide)
            {
                rb.velocity = Vector3.zero;
                stopSlide = false;
                Debug.Log("stop");
            }
        }
        else
        {
            grounded = false;
            stopSlide = true;
        }
        anim.SetBool("jump", !grounded);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Collectables"))
        {
            rb.isKinematic = true;
            Debug.Log("bla");
        }
    }
}
