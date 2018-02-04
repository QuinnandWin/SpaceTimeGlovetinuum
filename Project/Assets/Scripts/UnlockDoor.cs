using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour {

    [SerializeField]
    protected GameObject door;

    void OnTriggerEnter(Collider key)
    {
        if (key.gameObject.tag == "Key")
        {
            print("key has unlocked door");
            door.SetActive(false);
            Destroy(key.gameObject);
        }
    }
}
