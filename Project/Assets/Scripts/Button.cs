using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField]
    private string[] tagsToCheck;
    [SerializeField]
    private bool standardButton = false;
    [SerializeField]
    private bool pressureButton = false;
    [SerializeField]
    private bool multiButton = false;
    [SerializeField]
    public bool buttonIsOn = false;
    [SerializeField]
    private bool checkedButtonOnce = false;
    [SerializeField]
    private bool timerButton = false;
    [SerializeField]
    private float timeGiven = 10.0f;
    [SerializeField]
    private AudioClip timerSound;
    [SerializeField]
    private AudioClip buttonEndSound;
    [SerializeField]
    private AudioClip buttonOnSound;
    [SerializeField]
    private AudioClip buttonOffSound;
    private AudioSource buttonAudioSource;
    private float timeLeft = 0.0f;
    [SerializeField]
    private UnityEvent buttonOnEvents;
    [SerializeField]
    private UnityEvent buttonOffEvents;
    private Animator animatorHandler;

    void Awake()
    {
        timeLeft = timeGiven;
        buttonAudioSource = GetComponent<AudioSource>();
        animatorHandler = GetComponentInParent<Animator>();
    }
    void Update()
    {
        if (buttonIsOn == true && timerButton == true)
        {
            //start timer
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                timeLeft = timeGiven;
                buttonIsOn = false;
                TriggerButton();
            }
        }
    }

    void OnEnable()
    {
        if (buttonIsOn)
        {
            animatorHandler.SetBool("ButtonPressed", true);
        }
    }

    void OnTriggerEnter(Collider player)
    {
        bool matches = false;
        for (int i = 0; i < tagsToCheck.Length; i++)
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
                }
                else
                {
                    print("player turned standard button off");
                    buttonIsOn = false;
                }

                TriggerButton();
            }
            if (pressureButton == true)
            {
                print("player turned pressure button on");
                buttonIsOn = true;
                TurnOnButton();
            }
            if (multiButton == true && buttonIsOn == false)
            {
                buttonIsOn = true;
                print("player turned multi button on");
                TriggerButton();
                print("player turned multi button off");
            }
            if (timerButton == true)
            {
                buttonIsOn = true;
                timeLeft = timeGiven;
                TurnOnButton();
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
                TurnOffButton();
            }
        }
    }

    public void ChangeButton(bool value)
    {
        buttonIsOn = value;
        TriggerButton();
    }

    private void TriggerButton()
    {
        if (buttonIsOn)
            TurnOnButton();
        else
            TurnOffButton();
    }

    private void TurnOnButton()
    {
        buttonOnEvents.Invoke();
        buttonAudioSource.Stop();
        buttonAudioSource.loop = false;
        buttonAudioSource.PlayOneShot(buttonOnSound);
        animatorHandler.SetBool("ButtonPressed", true);
    }
    private void TurnOffButton()
    {
        buttonOffEvents.Invoke();
        buttonAudioSource.Stop();
        buttonAudioSource.loop = false;
        buttonAudioSource.PlayOneShot(buttonOffSound);
        animatorHandler.SetBool("ButtonPressed", false);
    }
}
