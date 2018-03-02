using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public Vector3 playerRespawnPoint;

    public void Start()
    {
        playerRespawnPoint = transform.position;
    }
    public void RespawnPlayer()
    {
        transform.position = playerRespawnPoint;
    }
    public void KillPlayer()
    {
        gameObject.SetActive(false);
    }
}
