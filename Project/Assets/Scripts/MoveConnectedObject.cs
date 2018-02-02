using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConnectedObject : MonoBehaviour {

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            print("player enter platform");
            player.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            print("player exit platform");
            player.transform.parent = null;
        }
    }
}
