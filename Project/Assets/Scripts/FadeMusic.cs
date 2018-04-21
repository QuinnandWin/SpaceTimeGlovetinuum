using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    [SerializeField]
    AudioSource musicToBeFaded;
    [SerializeField]
    float fadeTime;

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public void ActivateFade()
    {
        StartCoroutine(FadeMusic.FadeOut(musicToBeFaded, fadeTime));
    }
    void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            ActivateFade();
        }
    }



}
