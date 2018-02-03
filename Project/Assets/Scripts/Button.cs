using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    [SerializeField]
    protected bool standardButton = false;
    [SerializeField]
    protected bool pressureButton = false;
    [SerializeField]
    protected bool multiButton = false;
    [SerializeField]
    protected bool buttonIsOn = false;
    [SerializeField]
    protected bool checkedButtonOnce = false;
    [SerializeField]
    protected GameObject[] alternativeButtons;
    [SerializeField]
    protected GameObject[] affectedObjects;
// Use this for initialization
void Start () {

    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnEnable()
    {
        if (buttonIsOn)
        {
            for (int i = 0; i < affectedObjects.Length; i++)
            {
                affectedObjects[i].SetActive(true);
            }
        }
        else if (buttonIsOn == false)
        {
            for (int i = 0; i < affectedObjects.Length; i++)
            {
                affectedObjects[i].SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (standardButton == true)
            {
                if (buttonIsOn == false)
                {
                    print("player turned standard button on");
                    buttonIsOn = true;
                    for (int i = 0; i < affectedObjects.Length; i++)
                    {
                        affectedObjects[i].SetActive(true);
                    }
                }
                else if (buttonIsOn == true)
                {
                    print("player turned standard button off");
                    buttonIsOn = false;
                    for (int i = 0; i < affectedObjects.Length; i++)
                    {
                        affectedObjects[i].SetActive(false);
                    }
                }
            }
            if (pressureButton == true)
            {
                print("player turned pressure button on");
                buttonIsOn = true;
                for (int i = 0; i < affectedObjects.Length; i++)
                {
                    affectedObjects[i].SetActive(true);
                }
            }
            if ( multiButton == true)
            {
                buttonIsOn = true;
                print("player turned multi button on");
                for (int i = 0; i < affectedObjects.Length; i++)
                {
                    affectedObjects[i].SetActive(true);
                }
                for (int i = 0; i < alternativeButtons.Length; i++)
                {
                    alternativeButtons[i].GetComponent<Button>().buttonIsOn = false;
                    for (int x = 0; x < alternativeButtons[i].GetComponent<Button>().affectedObjects.Length; x++)
                    {
                        alternativeButtons[i].GetComponent<Button>().affectedObjects[x].SetActive(false);
                    }
                    print("player turned multi button off");
                }
            }
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (pressureButton == true)
            {
                print("player turned pressure button off");
                buttonIsOn = false;
                for (int i = 0; i < affectedObjects.Length; i++)
                {
                    affectedObjects[i].SetActive(false);
                }
            }
        }
    }
}
