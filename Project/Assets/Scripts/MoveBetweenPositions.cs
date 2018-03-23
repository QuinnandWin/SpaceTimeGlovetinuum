using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPositions : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 2.0f;
    [SerializeField]
    private Vector3 positionToMoveOffset;
    private Vector3 startPosition;
    [SerializeField]
    private bool stopsAtReverse = true;
    [SerializeField]
    private float timeStopped = 1.0f;
    [SerializeField]
    private bool paused = false;
    private bool reversing = false;
    private bool waiting = false;
    private float timeStoppedLeft = 0.0f;

    // Use this for initialization
    void Start () {
        startPosition = GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (paused == false)
        {
            if(waiting ==true)
            {
                //stop time for seconds
                timeStoppedLeft -= Time.deltaTime;
                if(timeStoppedLeft<0.0f)
                {
                    waiting = false;
                    reversing = !reversing;
                }
            }
            else if (reversing == false)
            {
                //go towards postion to move to
                Vector3 newPos = Vector3.MoveTowards(transform.position, startPosition + positionToMoveOffset, movementSpeed/50.0f);
                transform.position = newPos;
                if(Vector3.Distance(transform.position, startPosition + positionToMoveOffset) < 0.01f)
                {
                    if(stopsAtReverse)
                    {
                        waiting = true;
                        timeStoppedLeft = timeStopped;
                    }
                    else
                    {
                        reversing = true;
                    }
                }
            }
            else if (reversing == true)
            {
                //go towards start position
                Vector3 newPos = Vector3.MoveTowards(transform.position, startPosition, movementSpeed / 50.0f);
                transform.position = newPos;
                if (Vector3.Distance(transform.position, startPosition) < 0.01f)
                {
                    if (stopsAtReverse)
                    {
                        waiting = true;
                        timeStoppedLeft = timeStopped;
                    }
                    else
                    {
                        reversing = false;
                    }
                }
            }
        }
	}

    public void TogglePause()
    {
        paused = !paused;
    }

    public void SetPause(bool value)
    {
        paused = value;
    }
}
