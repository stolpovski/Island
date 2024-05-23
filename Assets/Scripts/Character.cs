using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    CharacterController controller;

    public float gravity = 9.81f;
    public Transform cam;
    public float speed;

    float upSpeed;

    private Vector2 movement;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        

        upSpeed -= 20 * Time.deltaTime;

        controller.Move((transform.up * upSpeed + transform.forward * movement.y * speed + transform.right * movement.x * speed) * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, cam.localEulerAngles.y, 0);
    }

    void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }

    void OnJump()
    {
        if (controller.isGrounded)
        {
            upSpeed = gravity;
        }
    }
}
