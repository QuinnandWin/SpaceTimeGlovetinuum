using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField]
    private AudioClip levelEndClip;
    private AudioSource endAudioSource;
    private GameObject playerObject;
    private Animator endAnimator;
    [SerializeField]
    private GameObject musicObject;

    private float yRotationSpeed = 45.0f;
    private float yRotation;

    // Use this for initialization
    void Start()
    {
        endAudioSource = GetComponent<AudioSource>();
        endAnimator = GetComponent<Animator>();

        yRotation = GetComponent<Transform>().eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        yRotation += yRotationSpeed * Time.deltaTime;
        GetComponent<Transform>().eulerAngles = new Vector3(0, yRotation, 0);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerObject = player.gameObject;
            EndLevel();
            Invoke("LoadOverworld", 5.0f);
            //StartCoroutine(AsyncLoadOverworld());
        }
    }

    void EndLevel()
    {
        playerObject.GetComponent<BasicMovement>().enabled = false;
        playerObject.GetComponent<Collider>().enabled = false;
        playerObject.GetComponent<Rigidbody>().isKinematic = true;

        musicObject.SetActive(false);
        endAudioSource.clip = levelEndClip;
        endAudioSource.Play();

        endAnimator.SetBool("LevelComplete", true);
        playerObject.GetComponent<Animator>().enabled = true;
        playerObject.GetComponent<Animator>().SetBool("LevelComplete", true);
    }

    IEnumerator AsyncLoadOverworld()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level 2");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    void LoadOverworld()
    {
        SceneManager.LoadScene("Level2");
    }

}
