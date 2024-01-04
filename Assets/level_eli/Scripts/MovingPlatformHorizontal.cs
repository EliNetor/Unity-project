using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformHorizontal : MonoBehaviour
{
    public float speed = 2.0f;
    public float maxOffset = 2.0f;
    bool colliding = false;

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the platform
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Move the platform
        MovePlatform();

        if (colliding)
        {
            GameObject childObject = GameObject.FindGameObjectWithTag("Player");
            if (childObject.gameObject.GetComponent<Animator>().GetInteger("state") != 0)
            {
                childObject.gameObject.transform.SetParent(null);
            }
            else
            {
                childObject.gameObject.transform.SetParent(transform);
            }
        }

    }

    void MovePlatform()
    {
        // Calculate the vertical offset based on the sine function
        float offsetX = Mathf.Sin(Time.time * speed) * maxOffset;

        // Update the platform's position relative to the initial position
        transform.position = initialPosition + new Vector3(offsetX, 0.0f, 0.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
            colliding = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
            colliding = false;
        }
    }

}