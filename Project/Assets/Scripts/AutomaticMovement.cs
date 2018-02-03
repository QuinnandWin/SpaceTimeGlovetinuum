using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour {
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
    float movementTimeLeft = 0.0f;
    float rotationTimeLeft = 0.0f;

    // Use this for initialization
    void Start () {
        movementTimeLeft = timeUntilMovementReverse;
        rotationTimeLeft = timeUntilRotationReverse;
    }
	
	// Update is called once per frame
	void Update () {
        var x = Time.deltaTime * xMovementSpeed;
        var y = Time.deltaTime * yMovementSpeed;
        var z = Time.deltaTime * zMovementSpeed;
        transform.Translate(x, y, z);

        var xRot = Time.deltaTime * xRotationSpeed;
        var yRot = Time.deltaTime * yRotationSpeed;
        var zRot = Time.deltaTime * zRotationSpeed;
        transform.Rotate(xRot, yRot, zRot);

        movementTimeLeft -= Time.deltaTime;
        if (movementTimeLeft <= 0 && movementReverse == true)
        {
            xMovementSpeed *= -1.0f;
            yMovementSpeed *= -1.0f;
            zMovementSpeed *= -1.0f;
            movementTimeLeft = timeUntilMovementReverse;
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
