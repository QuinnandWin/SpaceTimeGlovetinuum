using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{

    private bool timeIsStopped = false;
    public GameObject[] stoppableObjects;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        ActivateTimeStop();

    }

    void FixedUpdate()
    {

    }

    bool released = true;
    void ActivateTimeStop()
    {
        /*if (Input.GetAxis("Ability") > 0)
        {
            if (timeIsStopped == false && released)
            {
                timeIsStopped = true;
                for (int i = 0; i < stoppableObjects.Length; i++)
                {
                    stoppableObjects[i].GetComponent<AutomaticMovement>().stopTimeActivated = true;
                }
                print(timeIsStopped);
            }
            else if (timeIsStopped == true && released)
            {
                timeIsStopped = false;
                for (int i = 0; i < stoppableObjects.Length; i++)
                {
                    stoppableObjects[i].GetComponent<AutomaticMovement>().stopTimeActivated = false;
                }
                print(timeIsStopped);
            }
            released = false;
        }
        else
        {
            released = true;
        }*/
    }
}
