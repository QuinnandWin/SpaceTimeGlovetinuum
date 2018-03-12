using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConnectedObject : MonoBehaviour {

    void OnTriggerEnter(Collider player)
    {
            print("object enter platform");
            player.transform.parent = this.transform;
    }

    void OnTriggerExit(Collider player)
    {
            print("object exit platform");
        if (player.transform.parent == transform)
            player.transform.parent = null;
    }
}
