using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 movementSpeed;
    [SerializeField]
    protected float xRotationSpeed = 0.0f;
    [SerializeField]
    protected float yRotationSpeed = 0.0f;
    [SerializeField]
    protected float zRotationSpeed = 0.0f;
    [SerializeField]
    protected float timeUntilMovementReverse = 2.0f;
    [SerializeField]
    protected float timeUntilRotationReverse = 2.0f;
    [SerializeField]
    protected bool movementReverse = false;
    [SerializeField]
    protected bool rotationReverse = false;
    [SerializeField]
    protected bool stopsAtReverse = false;
    [SerializeField]
    protected float timePlatformIsStopped = 1.0f;
    private float timeStoppedLeft = 0.0f;
    private float movementTimeLeft = 0.0f;
    private float rotationTimeLeft = 0.0f;
    private float tempx = 0.0f;
    private float tempy = 0.0f;
    private float tempz = 0.0f;
    private bool stopped = false;
    public bool stopTimeActivated = false;
    private bool moving = true;

    // Use this for initialization
    void Start()
    {
        if (stopsAtReverse == false)
        {
            timePlatformIsStopped = 0.0f;
        }
        movementTimeLeft = timeUntilMovementReverse;
        rotationTimeLeft = timeUntilRotationReverse;
        timeStoppedLeft = 0.0f;
        tempx = movementSpeed.x;
        tempy = movementSpeed.y;
        tempz = movementSpeed.z;

        if (stopTimeActivated == false)
        {
            if (stopsAtReverse)
                Invoke("StopMovement", timeUntilMovementReverse);
            else
                Invoke("ReverseMovement", timeUntilMovementReverse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTimeActivated == false)
        {
            if (moving)
            {
                // lerp(pos1, pos2, moveTime)
                //if(pos = pos1 || pos == pos2)
                // stop/swap pos
                var x = Time.deltaTime * movementSpeed.x;
                var y = Time.deltaTime * movementSpeed.y;
                var z = Time.deltaTime * movementSpeed.z;
                transform.Translate(x, y, z);
            }

            var xRot = Time.deltaTime * xRotationSpeed;
            var yRot = Time.deltaTime * yRotationSpeed;
            var zRot = Time.deltaTime * zRotationSpeed;
            transform.Rotate(xRot, yRot, zRot);

            /*
            if (stopsAtReverse == true)
            {
                if (timeStoppedLeft > 0)
                {
                    timeStoppedLeft -= Time.deltaTime;

                    if (stopped == false)
                    {
                        StopMovement();
                    }
                }
            }
            if (timeStoppedLeft <= 0 && movementReverse == true)
            {
                movementTimeLeft -= Time.deltaTime;
                movementSpeed.x = tempx;
                movementSpeed.y = tempy;
                movementSpeed.z = tempz;
            }
            if (movementTimeLeft <= 0 && movementReverse == true)
            {
                tempx *= -1.0f;
                tempy *= -1.0f;
                tempz *= -1.0f;
                movementTimeLeft = timeUntilMovementReverse;
                timeStoppedLeft = timePlatformIsStopped;
                stopped = false;
            }
            */
            rotationTimeLeft -= Time.deltaTime;
            if (rotationTimeLeft <= 0 && rotationReverse == true)
            {
                xRotationSpeed *= -1.0f;
                yRotationSpeed *= -1.0f;
                zRotationSpeed *= -1.0f;
                rotationTimeLeft = timeUntilRotationReverse;
            }
        }
    }

    private void StopMovement()
    {
        /*
        tempx = movementSpeed.x;
        tempy = movementSpeed.y;
        tempz = movementSpeed.z;
        movementSpeed.x = 0.0f;
        movementSpeed.y = 0.0f;
        movementSpeed.z = 0.0f;
        */
        moving = false;

        Invoke("ReverseMovement", timePlatformIsStopped);
    }

    private void ReverseMovement()
    {
        moving = true;
        movementSpeed.x = -movementSpeed.x;
        movementSpeed.y = -movementSpeed.y;
        movementSpeed.z = -movementSpeed.z;

        if (stopsAtReverse)
            Invoke("StopMovement", timeUntilMovementReverse);
        else
            Invoke("ReverseMovement", timeUntilMovementReverse);
    }

    public void ToggleMovement()
    {
        stopTimeActivated = !stopTimeActivated;
    }
}
