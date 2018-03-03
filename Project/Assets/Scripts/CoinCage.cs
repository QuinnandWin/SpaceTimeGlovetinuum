using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCage : MonoBehaviour {

    [SerializeField]
    private float coinsRequired = 100;
    private float coinsAquired;

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            coinsAquired = CoinManager.coins;
            if(coinsAquired>=coinsRequired)
            {
                Destroy(this.gameObject, 0.0f);
            }
            else
            {
                print("Not enough coins");
            }
        }
    }
}
