using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gameCameraObject;
    [SerializeField]
    private Camera gameCamera;
    [SerializeField]
    private bool followX = true;
    [SerializeField]
    private bool followY = true;
    [SerializeField]
    private bool followZ = true;
    [SerializeField]
    private float xAngle = 45.0f;
    [SerializeField]
    private float yAngle = 0.0f;
    [SerializeField]
    private float zAngle = 0.0f;
    [SerializeField]
    private float cameraXPosition = 0.0f;
    [SerializeField]
    private float cameraYPosition = 6.0f;
    [SerializeField]
    private float cameraZPosition = -6.0f;
    [SerializeField]
    private float cameraFOV = 60.0f;
    private bool cameraInside = false;
    /* private float timer = 0.0f;
     private float previousCameraX = 0.0f;
     private float previousCameraY = 0.0f;
     private float previousCameraZ = 0.0f;
     private float differenceInX = 0.0f;
     private float differenceInY = 0.0f;
     private float differenceInZ = 0.0f;
     private float currentCameraXPosition;
     private float currentCameraYPosition;
     private float currentCameraZPosition;*/

    private bool animating = false;
    // Use this for initialization
    void Start()
    {
        gameCamera.fieldOfView = cameraFOV;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraInside)
        {
            //All different variations based on whether the camera is following the players x, y and z position.
            if (followX || followY || followZ)
            {
                //timer += Time.deltaTime;
                gameCamera.transform.eulerAngles = new Vector3(xAngle, yAngle, zAngle);
                animating = false;
                if (animating == false)
                {
                    float realX = cameraXPosition;
                    if (followX)
                        realX = player.transform.position.x + cameraXPosition;
                    float realY = cameraYPosition;
                    if (followY)
                        realY = player.transform.position.y + cameraYPosition;
                    float realZ = cameraZPosition;
                    if (followZ)
                        realZ = player.transform.position.z + cameraZPosition;

                    gameCamera.transform.position = new Vector3(realX, realY, realZ);
                }
                else
                {

                }
                /*
                if (followX && followY && followZ)
                {
                     for (int i = 0; i < 1; i++)
                     {
                         previousCameraX = 0;
                         currentCameraXPosition = previousCameraX;
                         differenceInX = cameraXPosition - previousCameraX;

                         previousCameraY = 2.0f;
                         currentCameraYPosition = previousCameraY;
                         differenceInY = cameraYPosition - previousCameraY;

                         previousCameraZ = -2.0f;
                         currentCameraZPosition = previousCameraZ;
                         differenceInZ = cameraZPosition - previousCameraZ;
                     }
                     while (currentCameraXPosition < cameraXPosition)
                     {
                         currentCameraXPosition += differenceInX * Time.deltaTime;
                     }

                         currentCameraYPosition += differenceInY * Time.deltaTime;

                     while (currentCameraZPosition > cameraZPosition)
                     {
                         currentCameraZPosition += differenceInZ * Time.deltaTime;
                     }

                     gameCamera.transform.position = new Vector3(player.transform.position.x,
                     player.transform.position.y + currentCameraYPosition,
                     player.transform.position.z + currentCameraZPosition);
                     
                }*/
            }
        }
    }

    private IEnumerator Animate()
    {
        float startTime = Time.time;
        float endTime = Time.time + 1.0f;

        while(true)
        {

        }

        yield return null;
    }


    void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            gameCamera.transform.eulerAngles = new Vector3(xAngle, yAngle, zAngle);
            cameraInside = true;
            //animating = true;
        }
    }

    void OnTriggerExit(Collider playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            cameraInside = false;
            //timer = 0.0f;
        }
    }
}
