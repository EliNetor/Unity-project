using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = false;
    private const float minJumpForce = 300f;
    private const float maxJumpForce = 600f;
    private const float chargeRate = 800f; // Adjust as needed for quicker charging
    private float currentJumpForce = 0f;
    private Animator animator;
    private CapsuleCollider sc;
    private float ogY;
    private float ogH;
    private PlayerMovement playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sc = GetComponent<CapsuleCollider>();
        ogY = sc.center.y;
        ogH = sc.height;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space) && currentJumpForce < maxJumpForce)
            {

                currentJumpForce += chargeRate * Time.deltaTime;

                // Limit the charging to the maximum jump force
                currentJumpForce = Mathf.Min(currentJumpForce, maxJumpForce);
                // animator.SetBool("Kneeldown", true);

            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                // Ensure a minimum jump force is applied even if the player releases quickly
                float jumpForceToApply = Mathf.Max(currentJumpForce, minJumpForce);
                rb.AddForce(Vector3.up * jumpForceToApply);
                animator.SetBool("jumping", true);
                animator.SetInteger("state", 2);
                sc.height = 1.6f;
                playerMovement.SetIsJumping(true);
                Vector3 jumpDirection = Vector3.zero;

                if (Input.GetKey(KeyCode.W))
                {
                    jumpDirection += transform.forward;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    jumpDirection -= transform.forward;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    jumpDirection -= transform.right;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    jumpDirection += transform.right;
                }

                if (jumpDirection != Vector3.zero)
                {
                    // Normalize the jump direction to prevent faster diagonal jumps
                    jumpDirection = jumpDirection.normalized;

                    // Apply a force in the chosen direction
                    Vector3 directionalJump = jumpDirection * 7; // Adjust this value as needed
                    rb.AddForce(directionalJump, ForceMode.Impulse);
                }

                sc.center = new Vector3(sc.center.x, 1.2f, sc.center.z);
                Debug.Log("Setting animation state to 2");

                // Reset charge and jump force variables
                currentJumpForce = 0f;


            }
        }

        if (stateInfo.IsName("jump1") && stateInfo.normalizedTime >= 1.0f)
        {
            animator.SetInteger("state", 3);
            Debug.Log("Setting animation state to 3");
        }

        if (animator.GetInteger("state") == 3 && isGrounded)
        {
            animator.SetInteger("state", 4);
            Debug.Log("Setting animation state to 4");
        }

        if (stateInfo.IsName("jump3") && stateInfo.normalizedTime >= 0.1f && isGrounded)
        {
            animator.SetInteger("state", 5);
            Debug.Log("Setting animation state to 5");
            animator.SetBool("jumping", false);
            sc.height = ogH;
            sc.center = new Vector3(sc.center.x, ogY, sc.center.z);
        }
        else if(!isGrounded)
        {
            animator.SetInteger("state", 2);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            playerMovement.SetIsJumping(false);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
