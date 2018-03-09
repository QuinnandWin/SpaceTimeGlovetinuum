using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainCoins : MonoBehaviour {

    [SerializeField]
    private bool isCoin = false;
    [SerializeField]
    private bool isSuperCoin = false;
    private ParticleSystem coinParticles;

    private float yRotationSpeed = 45.0f;
    private float yRotation;


    // Use this for initialization
    void Start () {

        yRotation = GetComponent<Transform>().eulerAngles.y;
        coinParticles = GetComponentInChildren<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update () {
        yRotation += yRotationSpeed * Time.deltaTime;
        GetComponent<Transform>().eulerAngles = new Vector3(0, yRotation, 0);
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
            coinParticles.Play();

            DestroyObject(this.gameObject, 1.0f);
        }
    }

}
