using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnJump : MonoBehaviour {

    private bool firstJumpInvoked = false;
    private bool secondJumpInvoked = false;
    private float jumpCounter = 0;
    [SerializeField]
    private GameObject redPlatforms;
    [SerializeField]
    private GameObject invisibleRedPlatforms;
    [SerializeField]
    private GameObject greenPlatforms;
    [SerializeField]
    private GameObject invisibleGreenPlatforms;
    [SerializeField]
    private AudioClip platformOnSound;
    [SerializeField]
    private AudioClip platformOffSound;
    [SerializeField]
    private AudioSource platformAudioSource;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        jumpCounter = GetComponent<BasicMovement>().jumpCounter;
        
        if(jumpCounter==0)
        {
            firstJumpInvoked = false;
            secondJumpInvoked = false;
        }
        else if (jumpCounter == 1 && firstJumpInvoked == false)
        {
            SwitchActive();
            firstJumpInvoked = true;
        }
        else if (jumpCounter == 2 && secondJumpInvoked == false)
        {
            SwitchActive();
            secondJumpInvoked = true;
        }
    }

    void SwitchActive()
    {
        if (redPlatforms.active == true)
        {
            redPlatforms.SetActive(false);
            invisibleRedPlatforms.SetActive(true);
            platformAudioSource.Stop();
            platformAudioSource.PlayOneShot(platformOnSound);
        }
        else if (redPlatforms.active == false)
        {
            redPlatforms.SetActive(true);
            invisibleRedPlatforms.SetActive(false);
            platformAudioSource.Stop();
            platformAudioSource.PlayOneShot(platformOffSound);
        }

        if (greenPlatforms.active == true)
        {
            greenPlatforms.SetActive(false);
            invisibleGreenPlatforms.SetActive(true);
        }
        else if (greenPlatforms.active == false)
        {
            greenPlatforms.SetActive(true);
            invisibleGreenPlatforms.SetActive(false);
        }
    }
}
