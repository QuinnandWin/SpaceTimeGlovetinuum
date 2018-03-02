using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider teleportedObject)
    {
        if (teleportedObject.gameObject.tag == "Player")
        {
            teleportedObject.GetComponent<PlayerHealth>().playerRespawnPoint = transform.position;
        }
    }
}
