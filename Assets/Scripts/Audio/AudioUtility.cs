using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUtility : MonoBehaviour
{
    public static void PlayOneShotWithRandomization(AudioSource audioSource, AudioClip audioClip, float volume)
    {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.volume = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(audioClip, volume);
    }

    public static void PlayOneShotWithRandomization(AudioSource audioSource, AudioClip[] audioClipArray, float volume)
    {
        audioSource.pitch = Random.Range(0.85f, 1.15f);
        audioSource.volume = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(audioClipArray[Random.Range(0, audioClipArray.Length)], volume);
    }
}
