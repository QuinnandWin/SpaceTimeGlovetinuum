using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public float speedIncreasePerFrame = 0.10f;
    public float maxspeed = 5.0f;
    private float currentSpeed = 1.50f;
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

        bool jumpPressed = false;
        if (Input.GetAxis("Jump") > 0.0f && characterIsOnGround == true)
        {
            jumpPressed = true;
            characterIsOnGround = false;
        }

        Move(x, z, jumpPressed, characterIsOnGround);



    }

    void Move(float x, float z, bool jumpPressed, bool characterIsOnGround)
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
            if (currentSpeed < 1.50f)
            {
                currentSpeed = 1.50f;
            }
        }


        if (jumpPressed == true)
        {
            y = 1.0f;
            jumpPressed = false;
        }

        movement.Set(x, y, z);
        //movement = movement.normalized;
        characterRigidbody.velocity = (movement * currentSpeed);
        //characterRigidbody.angularVelocity = 0.0f;

        printTimer++;
        if (printTimer == 15)
        {
            print(currentSpeed);
            printTimer = 0;
        }

        if (characterIsOnGround == false)
        {
            jumpTimer++;
        }
        if (jumpTimer >= 60)
        {
            y = 0.0f;
            print(y);
            print(characterRigidbody.velocity.y);
            if (characterRigidbody.velocity.y == 0.0f)
            {
                y = 0.0f;
                characterIsOnGround = true;
            }
        }
    }

    void Jump(float jumpPressedTime, bool jumpPressed)
    {
    }
}
