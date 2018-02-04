using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour {

    [SerializeField]
    protected GameObject teleportLocation;

    void OnTriggerEnter(Collider deadObject)
    {
        if (deadObject.gameObject.tag == "Player")
        {
            print("player has died");
            deadObject.transform.position = teleportLocation.transform.position;
        }
        if (deadObject.gameObject.tag == "Key")
        {
            print("key has died");
            deadObject.transform.position = teleportLocation.transform.position;
        }
    }

}
