using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour {
    
    [SerializeField]
    private GameObject playerObject;
    private Rigidbody keyRigidbody;

    private bool carryingObject = false;
    private bool playerWithinRange = false;
    private bool interactReleased = true;
    
	// Use this for initialization
	void Start () {
        keyRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Interact") > 0)
        {
            if (playerWithinRange == true  && carryingObject == false && interactReleased)
            {
                print("player has picked up object");
                transform.parent = playerObject.transform;
                transform.position = playerObject.transform.position;
                transform.Translate(0, 1.00f, 0);
                keyRigidbody.useGravity = false;
                carryingObject = true;
                GetComponent<Collider>().enabled = false;
            }
            else if (playerWithinRange == true && carryingObject == true && interactReleased)
            {
                print("player has dropped an object");
                transform.parent = null;
                keyRigidbody.useGravity = true;
                transform.Translate(0.0f, 0.3f, 0.3f);
                carryingObject = false;
                GetComponent<Collider>().enabled = true;
            }
            interactReleased = false;
        }
        else
        {
            interactReleased = true;
        }
        if (carryingObject)
        {
            transform.position = playerObject.transform.position;
            transform.Translate(0, 0.75f, 0);
        }
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerWithinRange = true;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerWithinRange = false;
        }
    }
}
