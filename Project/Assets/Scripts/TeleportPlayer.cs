using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour {

    [SerializeField]
    public GameObject teleportLocation;
    [SerializeField]
    private GameObject tempDeathObjects;
    [SerializeField]
    private bool checkpoint = false;

    void OnTriggerEnter(Collider teleportedObject)
    {
        if (teleportedObject.gameObject.tag == "Player")
        {
            if(checkpoint == false)
            {
                print("player has died");
                teleportedObject.transform.position = teleportLocation.transform.position;
            }
            else
            {
                tempDeathObjects.GetComponent<TeleportPlayer>().teleportLocation = this.gameObject;
            }
            
        }
        if (teleportedObject.gameObject.tag == "Key")
        {
            print("key has died");
            teleportedObject.transform.position = teleportLocation.transform.position;
        }
    }

}
