using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    private Animator anim;
    private bool isJumping = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isJumping)
        {
            // Get player input
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;

            // Move the character using physics
            GetComponent<Rigidbody>().MovePosition(transform.position + transform.TransformDirection(move) * speed * Time.deltaTime);

            if (horizontal == 0 && vertical == 0)
            {
                anim.SetInteger("state", 0);
            }
            else
            {
                anim.SetInteger("state", 1);
            }
        }
    }

    public void SetIsJumping(bool value)
    {
        isJumping = value;
    }
}
