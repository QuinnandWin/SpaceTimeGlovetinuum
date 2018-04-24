﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour {

    [SerializeField]
    public GameObject teleportLocation;
    [SerializeField]
    private GameObject tempDeathObjects;
    [SerializeField]
    private bool checkpoint = false;
    private AudioSource deathSound;
    private bool disableplayer = true;

    void Start()
    {
        deathSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider teleportedObject)
    {
        if (teleportedObject.gameObject.tag == "Player")
        {
            if(checkpoint == false)
            {
                print("player has died");
                DeathEffect();
                EnablePlayer(teleportedObject.gameObject);
                StartCoroutine(SpawnPlayer(3.0f, teleportedObject.gameObject));
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

    IEnumerator SpawnPlayer(float delay, GameObject playerToSpawn)
    {
        yield return new WaitForSeconds(delay);
        EnablePlayer(playerToSpawn);
        playerToSpawn.transform.position = teleportLocation.transform.position;
    }

    void DeathEffect()
    {
        deathSound.Play();

    }

    void EnablePlayer(GameObject player)
    {
        if(disableplayer == true)
        {
            player.SetActive(false);
        }
        else if (disableplayer == false)
        {
            player.SetActive(true);
        }

        disableplayer = !disableplayer;
    }


}
