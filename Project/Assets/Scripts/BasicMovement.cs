using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {
    [SerializeField]
    protected float playerMovementPerSecond = 0.0f;
    [SerializeField]
    protected float maxPlayerMovementPerSecond = 5.0f;
    [SerializeField]
    protected float minPlayerMovementPerSecond = 0.0f;
    [SerializeField]
    protected float playerJumpPerSecond = 5.0f;
    private float distanceToGround = 1.0f;
    Rigidbody playerRigidbody;
    Collider playerCollider;
    private Vector3 moveDirection = Vector3.zero;
    private float preJumpForwardMovement = 0.0f;
    private float preJumpSidewaysMovement = 0.0f;
    private float playerMovementPreJump = 0.0f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        distanceToGround = (playerCollider.bounds.size.y/2.0f);
    }

    void Update()
    {
        Run();
        Jump();
        print(playerRigidbody.velocity);
    }
    Vector3 direction;
    void Run()
    {
        float inputHoriziontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");        

        //Player acclerates from 0mps upto 5mps over the course of one second
        if (inputHoriziontal != 0.0f || inputVertical != 0.0f)
        {
            direction = new Vector3(inputHoriziontal, 0, inputVertical);
            direction.Normalize();

            playerMovementPerSecond += 5.0f * Time.deltaTime;
            if (playerMovementPerSecond >= maxPlayerMovementPerSecond)
            {
                playerMovementPerSecond = maxPlayerMovementPerSecond;
            }
            //print(playerMovementPerSecond);
        }
        //Player decceleartes from upto 5mps to 0mps over the course of 0.33 of a second
        if (inputHoriziontal == 0.0f && inputVertical == 0.0f)
        {
            playerMovementPerSecond -= 15.0f * Time.deltaTime;
            if (playerMovementPerSecond <= minPlayerMovementPerSecond)
            {
                playerMovementPerSecond = minPlayerMovementPerSecond;
            }
            //print(playerMovementPerSecond);
        }
        if (IsGrounded())
        {
            var x = direction.x * Time.deltaTime * playerMovementPerSecond * 60;
            var z = direction.z * Time.deltaTime * playerMovementPerSecond * 60;

            playerRigidbody.velocity = new Vector3(x, playerRigidbody.velocity.y, z);
            playerRigidbody.angularVelocity = Vector3.zero;          
        }

        if (IsGrounded()==false)
        {
            playerRigidbody.velocity += direction * Time.deltaTime * playerMovementPerSecond * 2;
            playerRigidbody.angularVelocity = Vector3.zero;

            float newX = playerRigidbody.velocity.x;
            float maxVelocityAir = 5.0f;
            if((inputHoriziontal > 0.8|| inputHoriziontal < -0.8) && 
                (inputVertical > 0.8 || inputVertical < -0.8))
            {
                maxVelocityAir = 3.6f;
            }
            if (newX > maxVelocityAir)
            {
                newX = maxVelocityAir;
            }
            else if(newX < -maxVelocityAir)
            {
                newX = -maxVelocityAir;
            }
            float newZ = playerRigidbody.velocity.z;
            if (newZ > maxVelocityAir)
                newZ = maxVelocityAir;
            else if (newZ < -maxVelocityAir)
                newZ = -maxVelocityAir;

            playerRigidbody.velocity = new Vector3(newX, playerRigidbody.velocity.y, newZ);
        }

    }
    bool released = true;
    void Jump()
    {
        IsGrounded();
        //print(IsGrounded());
        if (Input.GetAxis("Jump") > 0)
        {
            if (IsGrounded() && released)
            {
                playerRigidbody.velocity = new Vector3(0.0f, playerJumpPerSecond, 0.0f);
            }
            released = false;
        }
        else
        {
            released = true;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
 
}
