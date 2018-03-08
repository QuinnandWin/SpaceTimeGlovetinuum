using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    [SerializeField]
    protected float xMovementSpeed = 0.0f;
    [SerializeField]
    protected float yMovementSpeed = 0.0f;
    [SerializeField]
    protected float zMovementSpeed = 0.0f;
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
        tempx = xMovementSpeed;
        tempy = yMovementSpeed;
        tempz = zMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTimeActivated == false)
        {
            var x = Time.deltaTime * xMovementSpeed;
            var y = Time.deltaTime * yMovementSpeed;
            var z = Time.deltaTime * zMovementSpeed;
            transform.Translate(x, y, z);

            var xRot = Time.deltaTime * xRotationSpeed;
            var yRot = Time.deltaTime * yRotationSpeed;
            var zRot = Time.deltaTime * zRotationSpeed;
            transform.Rotate(xRot, yRot, zRot);

            if (stopsAtReverse == true)
            {
                if (timeStoppedLeft > 0)
                {
                    timeStoppedLeft -= Time.deltaTime;

                    if (stopped == false)
                    {
                        xMovementSpeed = 0.0f;
                        yMovementSpeed = 0.0f;
                        zMovementSpeed = 0.0f;
                        stopped = true;
                    }
                }
            }
            if (timeStoppedLeft <= 0 && movementReverse == true)
            {
                movementTimeLeft -= Time.deltaTime;
                xMovementSpeed = tempx;
                yMovementSpeed = tempy;
                zMovementSpeed = tempz;
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

    public void ToggleMovement()
    {
        stopTimeActivated = !stopTimeActivated;
    }
}
