using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = false;
    private const float jumpForce = 500f;
    private Animator animator;
    private CapsuleCollider sc;
    private float ogY;
    private float ogH;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sc = GetComponent<CapsuleCollider>();
        ogY = sc.center.y;
        ogH = sc.height;
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (isGrounded)
        {          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce);
                animator.SetBool("jumping", true);
                animator.SetInteger("state", 2);
                sc.height = 1.6f;
                sc.center = new Vector3(sc.center.x,1.2f, sc.center.z);
                Debug.Log("Setting animation state to 2");
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

        if (stateInfo.IsName("jump3") && stateInfo.normalizedTime >= 0.1f)
        {
            animator.SetInteger("state", 5);
            Debug.Log("Setting animation state to 5");
            animator.SetBool("jumping", false);
            sc.height = ogH;
            sc.center = new Vector3(sc.center.x, ogY, sc.center.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
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
