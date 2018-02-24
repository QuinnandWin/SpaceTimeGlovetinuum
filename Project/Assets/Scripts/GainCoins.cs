using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainCoins : MonoBehaviour {

    [SerializeField]
    private bool isCoin = false;
    [SerializeField]
    private bool isSuperCoin = false;
    [SerializeField]
    private AudioSource coinPickup;


    // Use this for initialization
    void Start () {
        coinPickup = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            if(isCoin)
            CoinManager.coins += 1;
            else if (isSuperCoin)
                CoinManager.superCoins += 1;

            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            coinPickup.Play();

            DestroyObject(this, 1.0f);
        }
    }

}
