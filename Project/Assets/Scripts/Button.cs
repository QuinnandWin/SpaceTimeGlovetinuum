using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    [SerializeField]
    private string[] tagsToCheck;
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
    [SerializeField]
    protected bool timerButton = false;
    [SerializeField]
    protected float timeGiven = 10.0f;
    [SerializeField]
    protected AudioClip timerSound;
    [SerializeField]
    protected AudioClip buttonEndSound;
    private AudioSource buttonAudioSource;
    private float timeLeft = 0.0f;
    [SerializeField]
    protected bool enableObject = true;
    [SerializeField]
    protected bool activateScript = false;

    void Start()
    {
        timeLeft = timeGiven;
        buttonAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (buttonIsOn ==true && timerButton == true)
        {
            //start timer
            timeLeft -= Time.deltaTime;

            if(timeLeft<=0)
            {
                timeLeft = timeGiven;
                buttonIsOn = false;
                if(enableObject==true)
                {
                    for (int i = 0; i < affectedObjects.Length; i++)
                    {
                        affectedObjects[i].SetActive(false);
                    }
                }
                else if (activateScript == true)
                {
                    for (int i = 0; i < affectedObjects.Length; i++)
                    {
                        affectedObjects[i].GetComponent<AutomaticMovement>().stopTimeActivated = true;
                    }
                }
                buttonAudioSource.clip = buttonEndSound;
                buttonAudioSource.loop = false;
                buttonAudioSource.Play();
            }
        }
    }

    void OnEnable()
    {
        if (buttonIsOn)
        {
            if (enableObject == true)
            {
                for (int i = 0; i < affectedObjects.Length; i++)
                {
                    affectedObjects[i].SetActive(true);
                }
            }
            else if (activateScript == true)
            {
                for (int i = 0; i < affectedObjects.Length; i++)
                {
                    affectedObjects[i].GetComponent<AutomaticMovement>().stopTimeActivated = false;
                }
            }
        }
        else if (buttonIsOn == false)
        {
            if (enableObject == true)
            {
                for (int i = 0; i < affectedObjects.Length; i++)
                {
                    affectedObjects[i].SetActive(false);
                }
            }
            else if (activateScript == true)
            {
                for (int i = 0; i < affectedObjects.Length; i++)
                {
                    affectedObjects[i].GetComponent<AutomaticMovement>().stopTimeActivated = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        bool matches = false;
        for(int i =0; i < tagsToCheck.Length; i++)
        {
            if (player.gameObject.tag == tagsToCheck[i])
            {
                matches = true;
            }
        }
        if (matches)
        {
            if (standardButton == true)
            {
                if (buttonIsOn == false)
                {
                    print("player turned standard button on");
                    buttonIsOn = true;
                    if (enableObject == true)
                    {
                        for (int i = 0; i < affectedObjects.Length; i++)
                        {
                            affectedObjects[i].SetActive(true);
                        }
                    }
                    else if (activateScript == true)
                    {
                        for (int i = 0; i < affectedObjects.Length; i++)
                        {
                            affectedObjects[i].GetComponent<AutomaticMovement>().stopTimeActivated = false;
                        }
                    }
                }
                else if (buttonIsOn == true)
                {
                    print("player turned standard button off");
                    buttonIsOn = false;
                    if (enableObject == true)
                    {
                        for (int i = 0; i < affectedObjects.Length; i++)
                        {
                            affectedObjects[i].SetActive(false);
                        }
                    }
                    else if (activateScript == true)
                    {
                        for (int i = 0; i < affectedObjects.Length; i++)
                        {
                            affectedObjects[i].GetComponent<AutomaticMovement>().stopTimeActivated = true;
                        }
                    }
                }
            }
            if (pressureButton == true)
            {
                print("player turned pressure button on");
                buttonIsOn = true;
                if (enableObject == true)
                {
                    for (int i = 0; i < affectedObjects.Length; i++)
                    {
                        affectedObjects[i].SetActive(true);
                    }
                }
                else if (activateScript == true)
                {
                    for (int i = 0; i < affectedObjects.Length; i++)
                    {
                        affectedObjects[i].GetComponent<AutomaticMovement>().stopTimeActivated = false;
                    }
                }
            }
            if ( multiButton == true)
            {
                buttonIsOn = true;
                print("player turned multi button on");
                if (enableObject == true)
                {
                    for (int i = 0; i < affectedObjects.Length; i++)
                    {
                        affectedObjects[i].SetActive(true);
                    }
                }
                else if (activateScript == true)
                {
                    for (int i = 0; i < affectedObjects.Length; i++)
                    {
                        affectedObjects[i].GetComponent<AutomaticMovement>().stopTimeActivated = false;
                    }
                }
                for (int i = 0; i < alternativeButtons.Length; i++)
                {
                    alternativeButtons[i].GetComponent<Button>().buttonIsOn = false;
                    if (enableObject == true)
                    {
                        for (int x = 0; x < affectedObjects.Length; x++)
                        {
                            affectedObjects[x].SetActive(false);
                        }
                    }
                    else if (activateScript == true)
                    {
                        for (int x = 0; x < affectedObjects.Length; x++)
                        {
                            affectedObjects[x].GetComponent<AutomaticMovement>().stopTimeActivated = true;
                        }
                    }
                    print("player turned multi button off");
                }
            }
            if (timerButton == true)
            {
                buttonIsOn = true;
                timeLeft = timeGiven;
                for (int i = 0; i < affectedObjects.Length; i++)
                {
                    affectedObjects[i].SetActive(true);
                }
                buttonAudioSource.clip = timerSound;
                buttonAudioSource.loop = true;
                buttonAudioSource.Play();
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
                if (enableObject == true)
                {
                    for (int i = 0; i < affectedObjects.Length; i++)
                    {
                        affectedObjects[i].SetActive(false);
                    }
                }
                else if (activateScript == true)
                {
                    for (int i = 0; i < affectedObjects.Length; i++)
                    {
                        affectedObjects[i].GetComponent<AutomaticMovement>().stopTimeActivated = true;
                    }
                }
            }
        }
    }
}
