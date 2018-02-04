using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour {

    [SerializeField]
    protected GameObject keyObject;
    [SerializeField]
    protected GameObject playerObject;
    private Rigidbody keyRigidbody;
    public bool carryingObject = false;
    private bool playerWithinRange = false;
	// Use this for initialization
	void Start () {
        keyRigidbody = keyObject.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        if (playerWithinRange == true && Input.GetKeyDown("e") == true && carryingObject == false)
        {
            print("player has picked up object");
            keyObject.transform.parent = playerObject.transform;
            keyObject.transform.position = playerObject.transform.position;
            keyObject.transform.Translate(0, 0.65f, 0);
            keyRigidbody.useGravity = false;
            carryingObject = true;
        }
        else if (playerWithinRange == true && Input.GetKeyDown("e") == true && carryingObject == true)
        {
            print("player has dropped an object");
            keyObject.transform.parent = null;
            keyRigidbody.useGravity = true;
            keyObject.transform.Translate(0.0f, 0.3f, 0.3f);
            carryingObject = false;
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
