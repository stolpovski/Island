using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    GameObject item;
    bool hasKey;
    CharacterController controller;

    public float gravity = 9.81f;
    public float jumpSpeed = 7f;
    public Transform cam;
    public float speed;
    bool jumped;

    float upSpeed;

    private Vector2 movement;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        

        if (controller.isGrounded)
        {
            
            upSpeed = 0;
            if (jumped)
            {
                upSpeed = jumpSpeed;
                jumped = false;
            }
        }
        else
        {
            upSpeed -= 20 * Time.deltaTime;
        }


        //Debug.Log(upSpeed);

        controller.Move((transform.up * upSpeed + transform.forward * movement.y * speed + transform.right * movement.x * speed) * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, cam.localEulerAngles.y, 0);
    }

    void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }

    void OnJump()
    {
        if (!jumped)
        {
            jumped = true;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Key")
        {
            item = other.gameObject;
        }

        if (other.name == "Chest")
        {
            item = other.gameObject;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Key")
        {
            item = null;

        }

        if (other.name == "Chest")
        {
            item = null;

        }
    }



    void OnUse()
    {
        if (item && item.name == "Key")
        {
            item.SetActive(false);
            GameObject.Find("KeyLabel").SetActive(false);
            hasKey = true;
        }

        if (item && item.name == "Chest" && hasKey)
        {
            item.GetComponent<Animator>().enabled = true;
        }
    }


 


}
