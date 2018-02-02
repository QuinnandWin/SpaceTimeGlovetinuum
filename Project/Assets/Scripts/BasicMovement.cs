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
    }

    void Run()
    {
        //Player acclerates from 0mps upto 5mps over the course of one second
        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            playerMovementPerSecond += 5.0f * Time.deltaTime;
            if (playerMovementPerSecond >= maxPlayerMovementPerSecond)
            {
                playerMovementPerSecond = maxPlayerMovementPerSecond;
            }
            //print(playerMovementPerSecond);
        }
        //Player decceleartes from upto 5mps to 0mps over the course of 0.33 of a second
        if (Input.GetAxis("Horizontal") == 0.0f && Input.GetAxis("Vertical") == 0.0f)
        {
            playerMovementPerSecond -= 15.0f * Time.deltaTime;
            if (playerMovementPerSecond <= minPlayerMovementPerSecond)
            {
                playerMovementPerSecond = minPlayerMovementPerSecond;
            }
            //print(playerMovementPerSecond);
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * playerMovementPerSecond;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * playerMovementPerSecond;

        transform.Rotate(0, 0, 0);
        transform.Translate(x, 0, z);
    }

    void Jump()
    {
        /* if (Input.GetAxis("Jump") != 0.0f)
         {
             playerJumpPerSecond += 5.0f * Time.deltaTime;
             if (playerJumpPerSecond >= maxPlayerMovementPerSecond)
             {
                 playerJumpPerSecond = maxPlayerMovementPerSecond;
             }
             //print(playerJumpPerSecond);
         }
         if (Input.GetAxis("Jump") == 0.0f)
         {
             playerJumpPerSecond -= 15.0f * Time.deltaTime;
             if (playerJumpPerSecond <= minPlayerMovementPerSecond)
             {
                 playerJumpPerSecond = minPlayerMovementPerSecond;
             }
             print(playerJumpPerSecond);
         } */
        IsGrounded();
        print(IsGrounded());
        if (Input.GetKeyDown("space") == true)
        {
            if (IsGrounded())
            {
                playerRigidbody.velocity = new Vector3(0.0f, playerJumpPerSecond, 0.0f);
            }
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
 
}
