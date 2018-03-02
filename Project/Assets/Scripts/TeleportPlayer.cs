using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    [SerializeField]
    public GameObject teleportLocation;
    [SerializeField]
    private bool checkpoint = false;

    void OnTriggerEnter(Collider teleportedObject)
    {
        if (teleportedObject.gameObject.tag == "Player")
        {
            print("player has died");
            teleportedObject.GetComponent<PlayerHealth>().RespawnPlayer();
        }

        if (teleportedObject.gameObject.tag == "Key")
        {
            print("key has died");
            teleportedObject.transform.position = teleportLocation.transform.position;
        }
    }

}
