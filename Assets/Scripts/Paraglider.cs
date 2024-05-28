using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paraglider : MonoBehaviour
{
    public bool boarded;
    public GameObject cam;
    public float pushForce;
    float speed;
    public float torque;
    float downForce;

    float pitch;
    float roll;
    float yaw;
    
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

        //body.AddRelativeForce(Vector3.forward * pushForce, ForceMode.Impulse);
    }

    void OnPitch(InputValue inputValue)
    {
        if (!boarded) return;

        pitch = inputValue.Get<float>();
    }

    void OnRoll(InputValue inputValue)
    {
        if (!boarded) return;
        roll = inputValue.Get<float>();
    }

    void OnYaw(InputValue inputValue)
    {
        if (!boarded) return;
        yaw = inputValue.Get<float>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < 0)
        {
            speed = 0;
            downForce = 20;
        }

        Vector3 force = Vector3.forward * speed * Time.fixedDeltaTime;

        //body.AddForce(Vector3.up + Physics.gravity);
        body.AddRelativeForce(force, ForceMode.Impulse);

        Quaternion target = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.eulerAngles, Vector3.forward), 1);
        
        //transform.Rotate(Vector3.up * yaw);

        body.AddRelativeTorque(Vector3.right * pitch * torque);
        body.AddRelativeTorque(Vector3.back * roll * torque);

        body.AddForce(Vector3.down * downForce * Time.fixedDeltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 1);
    }

    void OnCollisionEnter(Collision collision)
    {
        body.useGravity = true;
        speed = 0;
        downForce = 0;
    }

    void OnJump()
    {
        if (!this.enabled) return;

        speed = 5;
        downForce = 10;
    }
}
