using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private Collider sightCollider;
    [SerializeField]
    private Collider chaseCollider;
    [SerializeField]
    private float chaseSpeed = 2.0f;
    private GameObject playerObject;
    private Vector3 playerPosition;
    private bool chasingPlayer = false;
    private Animator enemyAnimationHandler;

    // Use this for initialization
    void Start () {

        sightCollider.enabled = true;
        chaseCollider.enabled = false;
        enemyAnimationHandler = GetComponentInParent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
        if(chasingPlayer == true)
        {
            playerPosition = playerObject.GetComponent<Transform>().position;
            ChasePlayer();
        }
	}

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            if(enemyAnimationHandler.GetBool("JustSeenPlayer")!=true)
            {
                enemyAnimationHandler.SetBool("JustSeenPlayer", true);
            }
            playerObject = player.gameObject; 
            Invoke("SetChasingPlayer", 0.75f);
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            playerObject = player.gameObject;
            chasingPlayer = false;
            MoveAround();
        }
    }

    void ChasePlayer()
    {
        enemyAnimationHandler.SetBool("JustSeenPlayer", false);
        sightCollider.enabled = false;
        chaseCollider.enabled = true;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, chaseSpeed*0.01f);
    }

    void MoveAround()
    {
        sightCollider.enabled = true;
        chaseCollider.enabled = false;
        print("enemy stopped chasing player");
    }

    void SetChasingPlayer()
    {
        if (chasingPlayer != true)
        {
            print("enemy chasing player");
            enemyAnimationHandler.SetBool("JustSeenPlayer", false);
            chasingPlayer = true;
        }
    }
}
