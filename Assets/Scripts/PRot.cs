using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRot : MonoBehaviour
{
    private Vector2 turn;
    public float sensitivity = 5f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }
}
