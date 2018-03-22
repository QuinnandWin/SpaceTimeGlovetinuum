using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConnectedObject : MonoBehaviour {

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            print("object enter platform");
            player.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            if (player.transform.parent == transform)
                player.transform.parent = null;
        }
    }
}
