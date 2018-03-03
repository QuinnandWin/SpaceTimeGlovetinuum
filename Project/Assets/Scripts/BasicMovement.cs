﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {
    [SerializeField]
    private float playerMovementPerSecond = 0.0f;
    [SerializeField]
    private float maxPlayerMovementPerSecond = 5.0f;
    [SerializeField]
    private float minPlayerMovementPerSecond = 0.0f;
    [SerializeField]
    private float playerJumpHeight = 6.0f;
    [SerializeField]
    private AudioClip firstJumpSound;
    [SerializeField]
    private AudioClip secondJumpSound;
    private AudioSource playerAudioSource;
    private float distanceToGround = 1.0f;
    Rigidbody playerRigidbody;
    Collider playerCollider;
    private Vector3 moveDirection = Vector3.zero;
    private float preJumpForwardMovement = 0.0f;
    private float preJumpSidewaysMovement = 0.0f;
    private float playerMovementPreJump = 0.0f;
    private int jumpCounter = 0;
    public Material NoJump;
    public Material FirstJump;
    public Material DoubleJump;
    public float timesSpeedBy = 30.0f;
    private float inputVertical=0.0f;
    private float inputHoriziontal = 0.0f;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        distanceToGround = (playerCollider.bounds.size.y/2.0f);
        playerAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        inputHoriziontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        //print(playerRigidbody.velocity);
        //Visual indicator for jumps
        if (jumpCounter==0)
        {
            GetComponent<Renderer>().material = NoJump;
            playerAudioSource.clip = null;
        }
        else if (jumpCounter == 1)
        {
            GetComponent<Renderer>().material = FirstJump;
            if(playerAudioSource.clip != firstJumpSound)
            { 
                playerAudioSource.clip = firstJumpSound;
                playerAudioSource.Play();
            }
        }
        else if (jumpCounter == 2)
        {
            GetComponent<Renderer>().material = DoubleJump;
            if (playerAudioSource.clip != secondJumpSound)
            {
                playerAudioSource.clip = secondJumpSound;
                playerAudioSource.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        Jump();
        Run();
    }
    Vector3 direction;
    void Run()
    {
      
        //Player acclerates from 0mps upto 5mps over the course of one second
        if (inputHoriziontal != 0.0f || inputVertical != 0.0f)
        {
            direction = new Vector3(inputHoriziontal, 0, inputVertical);
            direction.Normalize();

            playerMovementPerSecond += 5.0f * Time.unscaledDeltaTime;
            if (playerMovementPerSecond >= maxPlayerMovementPerSecond)
            {
                playerMovementPerSecond = maxPlayerMovementPerSecond;
            }
            //print(playerMovementPerSecond);
        }
        //Player decceleartes from upto 5mps to 0mps over the course of 0.33 of a second
        if (inputHoriziontal == 0.0f && inputVertical == 0.0f)
        {
            playerMovementPerSecond -= 30.0f * Time.unscaledDeltaTime;
            if (playerMovementPerSecond <= minPlayerMovementPerSecond)
            {
                playerMovementPerSecond = minPlayerMovementPerSecond;
            }
            //print(playerMovementPerSecond);
        }
        if (IsGrounded())
        {
            var x = direction.x * Time.unscaledDeltaTime * playerMovementPerSecond * timesSpeedBy;
            var z = direction.z * Time.unscaledDeltaTime * playerMovementPerSecond * timesSpeedBy;

            playerRigidbody.velocity = new Vector3(x, playerRigidbody.velocity.y, z);
            playerRigidbody.angularVelocity = Vector3.zero;          
        }

        if (IsGrounded()==false)
        {
            playerRigidbody.velocity += direction * Time.unscaledDeltaTime * playerMovementPerSecond * 2;
            playerRigidbody.angularVelocity = Vector3.zero;

            float newX = playerRigidbody.velocity.x;
            float newZ = playerRigidbody.velocity.z;
            float maxVelocityAir = 3.0f;
            //Velocity for first jump
            if (jumpCounter <= 1)
            {
                if ((inputHoriziontal > 0.8 || inputHoriziontal < -0.8) &&
                    (inputVertical > 0.8 || inputVertical < -0.8))
                {
                    maxVelocityAir = 2.3f;
                }
                if (newX > maxVelocityAir)
                {
                    newX = maxVelocityAir;
                }
                else if (newX < -maxVelocityAir)
                {
                    newX = -maxVelocityAir;
                }
                if (newZ > maxVelocityAir)
                    newZ = maxVelocityAir;
                else if (newZ < -maxVelocityAir)
                    newZ = -maxVelocityAir;
            }
            //Velocity for second jump
            if (jumpCounter >= 2)
            {
                maxVelocityAir = 1.5f;
                if ((inputHoriziontal > 0.8 || inputHoriziontal < -0.8) &&
                    (inputVertical > 0.8 || inputVertical < -0.8))
                {
                    maxVelocityAir = 1.1f;
                }
                if (newX > maxVelocityAir)
                {
                    newX = maxVelocityAir;
                }
                else if (newX < -maxVelocityAir)
                {
                    newX = -maxVelocityAir;
                }
                if (newZ > maxVelocityAir)
                    newZ = maxVelocityAir;
                else if (newZ < -maxVelocityAir)
                    newZ = -maxVelocityAir;
            }

            playerRigidbody.velocity = new Vector3(newX, playerRigidbody.velocity.y, newZ);
        }

    }
    bool released = true;
    void Jump()
    {
        if(IsGrounded() && released)
        {
            jumpCounter = 0;
        }
        if (Input.GetAxis("Jump") > 0)
        {
            if (IsGrounded() && released)
            {
                playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0.0f, playerRigidbody.velocity.z);
                playerRigidbody.velocity += new Vector3(0.0f, playerJumpHeight, 0.0f);
                jumpCounter++;
            }
            else if (jumpCounter <= 1 && released)
            {
                playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0.0f, playerRigidbody.velocity.z);
                playerRigidbody.velocity += new Vector3(0.0f, playerJumpHeight/1.5f, 0.0f);
                jumpCounter=2;
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
