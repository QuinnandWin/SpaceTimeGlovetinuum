using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenMultipleNodes: MonoBehaviour
{

    [SerializeField]
    private float movementSpeed = 2.0f;
    [SerializeField]
    private bool stopsAtNode = true;
    [SerializeField]
    private float timeStopped = 1.0f;
    [SerializeField]
    private bool paused = false;
    [SerializeField]
    private Transform[] platformLocations;
    private int nextNode = 0;
    private bool reversing = false;
    private bool waiting = false;
    private float timeStoppedLeft = 0.0f;

    // Use this for initialization
    void Start()
    {
        transform.position = platformLocations[0].position;
        nextNode = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (paused == false)
        {
            if (waiting == true)
            {
                //stop time for seconds
                timeStoppedLeft -= Time.deltaTime;
                if (timeStoppedLeft < 0.0f)
                {
                    waiting = false;
                }
            }
            else
            {
                //go towards postion to move to
                Vector3 newPos = Vector3.MoveTowards(transform.position, platformLocations[nextNode].position, movementSpeed * 0.01f);
                transform.position = newPos;
                if (transform.position == platformLocations[nextNode].position)
                {
                    if (stopsAtNode)
                    {
                        waiting = true;
                        timeStoppedLeft = timeStopped;
                    }
                    nextNode++;
                    if(nextNode>=platformLocations.Length)
                    {
                        nextNode = 0;
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
