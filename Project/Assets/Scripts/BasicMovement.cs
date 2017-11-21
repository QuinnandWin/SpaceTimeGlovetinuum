using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public float speedIncreasePerFrame = 0.10f;
    public float maxspeed = 5.0f;
    private float currentSpeed = 0.50f;
    Vector3 movement;
    Rigidbody characterRigidbody;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    //FixedUpdate processes physics every frame
    //x and y get values from wasd keys for movement
    //this is then used to calculate players velocity which is times by public speed so its easier to manipulate in unity
    void FixedUpdate()
    {
        float z = Input.GetAxis("Forwards");
        float x = Input.GetAxis("Sideways");
        Move(x, z);

    }

    void Move(float x, float z)
    {
        if (x != 0.0f || z != 0.0f)
        {
            currentSpeed += speedIncreasePerFrame;
            if (currentSpeed > maxspeed)
            {
                currentSpeed = maxspeed;
            }
        }

        if (x == 0.0f && z == 0.0f)
        {
            currentSpeed -= (speedIncreasePerFrame*2);
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }

        movement.Set(x, 0.0f, z);
        //movement = movement.normalized;
        characterRigidbody.velocity = (movement * currentSpeed);
        //characterRigidbody.angularVelocity = 0.0f;

        //System.Console()
    }
}
