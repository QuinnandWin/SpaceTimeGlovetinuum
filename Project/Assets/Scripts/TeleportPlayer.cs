using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour {

    [SerializeField]
    protected GameObject teleportLocation;

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            print("player has died");
            player.transform.position = teleportLocation.transform.position;
        }
    }

}
