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
        }

        else if (player.gameObject.tag == "Player" && activate == false)
        {
            cameraObject.GetComponent<SmoothCamera>().enabled = true;
            cameraObject.GetComponent<MoveBetweenMultipleNodes>().enabled = false;
        }
    }
}
