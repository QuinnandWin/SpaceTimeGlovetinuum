using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    [SerializeField]
    protected float speedIncreasePerFrame = 0.10f;
    [SerializeField]
    protected float maxspeed = 5.0f;
    [SerializeField]
    protected float startSpeed = 2.0f;
    private float currentSpeed = 2.0f;
    private float y = 0.0f;
    private int printTimer = 0;
    private int jumpTimer = 0;
    private bool characterIsOnGround=true;
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

        characterRigidbody.AddForce(x * currentSpeed, 0.0f, z * currentSpeed);

        Move(x, z);

        bool jumpPressed = false;
        if (Input.GetAxis("Jump") > 0.0f && characterIsOnGround == true)
        {
            jumpPressed = true;
            characterIsOnGround = false;
        }

        if (jumpPressed == true)
        {
            Jump(0.0f, true);
        }
        



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
            currentSpeed -= (speedIncreasePerFrame*10);
            if (currentSpeed < startSpeed)
            {
                currentSpeed = startSpeed;
            }
        }


        movement.Set(x, y, z);
        //movement = movement.normalized;
        characterRigidbody.AddForce(x * currentSpeed, 0.0f,z * currentSpeed);
        //characterRigidbody.velocity = (movement * currentSpeed);
        //characterRigidbody.angularVelocity = 0.0f;

        printTimer++;
        if (printTimer == 15)
        {
            print(currentSpeed);
            printTimer = 0;
        }

    }

    void Jump(float jumpPressedTime, bool characterIsOnGround)
    {
    }
}
