using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMovingCamera : MonoBehaviour {

    [SerializeField]
    bool activate = true;
    [SerializeField]
    GameObject cameraObject;
    [SerializeField]
    Transform startNode;
    [SerializeField]
    float xRotation;
    [SerializeField]
    Collider activationCameraBox;
    [SerializeField]
    GameObject deathEdge;
    [SerializeField]
    GameObject originalMusic;
    [SerializeField]
    bool movingCameraLevel = true;

    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && activate == true)
        {
            cameraObject.GetComponent<SmoothCamera>().enabled = false;
            cameraObject.GetComponent<MoveBetweenMultipleNodes>().enabled = true;
            cameraObject.transform.position = startNode.position;
            cameraObject.transform.rotation = Quaternion.Euler(xRotation, cameraObject.transform.rotation.y, cameraObject.transform.rotation.z);
            this.GetComponent<Collider>().enabled = false;
            deathEdge.gameObject.SetActive(true);
            originalMusic.gameObject.SetActive(false);
        }

        else if (player.gameObject.tag == "Player" && activate == false)
        {
            cameraObject.GetComponent<SmoothCamera>().enabled = true;
            if (movingCameraLevel == true)
            {
                cameraObject.GetComponent<MoveBetweenMultipleNodes>().enabled = false;
                activationCameraBox.enabled = true;
                deathEdge.gameObject.SetActive(false);
            }
            originalMusic.gameObject.SetActive(true);
        }
    }
}
