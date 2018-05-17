using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCage : MonoBehaviour {

    [SerializeField]
    private float coinsRequired = 100;
    private float coinsAquired;
    private AudioSource cageUnlock;
    [SerializeField]
    private GameObject cageObject;
    [SerializeField]
    private ParticleSystem cageEffect;

    void Awake()
    {
        cageUnlock = GetComponent<AudioSource>();


    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            coinsAquired = CoinManager.coins;
            if(coinsAquired>=coinsRequired)
            {
                cageUnlock.Play();
                cageObject.SetActive(false);
                cageEffect.Play();
                Destroy(this.gameObject, 1.0f);
            }
            else
            {
                print("Not enough coins");
            }
        }
    }
}
