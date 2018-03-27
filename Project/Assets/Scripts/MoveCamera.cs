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
    private bool cameraInside = false;
    [SerializeField]
    private bool disablesObjects = false;
    [SerializeField]
    private GameObject[] objectsToBeDisabled;
    [SerializeField]
    private bool enablesObjects = false;
    [SerializeField]
    private GameObject[] objectsToBeEnabled;
    [SerializeField]
    private bool automaticMovement = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       /* if (cameraInside)
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
        }*/
    }


    void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            cameraInside = false;
            gameCamera.GetComponent<SmoothCamera>().nextXPosition = cameraXPosition;
            gameCamera.GetComponent<SmoothCamera>().nextYPosition = cameraYPosition;
            gameCamera.GetComponent<SmoothCamera>().nextZPosition = cameraZPosition;
            gameCamera.GetComponent<SmoothCamera>().nextXAngle = xAngle;
            gameCamera.GetComponent<SmoothCamera>().nextYAngle = yAngle;
            gameCamera.GetComponent<SmoothCamera>().nextZAngle = zAngle;
            gameCamera.GetComponent<SmoothCamera>().followX = followX;
            gameCamera.GetComponent<SmoothCamera>().followY = followY;
            gameCamera.GetComponent<SmoothCamera>().followZ = followZ;
            gameCamera.GetComponent<SmoothCamera>().automaticMovementInX = automaticMovement;

            for (int i = 0; i<objectsToBeDisabled.Length; i++)
            {
                objectsToBeDisabled[i].SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            gameCamera.GetComponent<SmoothCamera>().playerPositionGrabbed = false;
            cameraInside = false;

            for (int i = 0; i < objectsToBeDisabled.Length; i++)
            {
                objectsToBeDisabled[i].SetActive(true);
            }
        }
    }
}
