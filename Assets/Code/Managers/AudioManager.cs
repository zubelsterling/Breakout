using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip brickBreakSound;
    public AudioClip collectPowerUpSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        subscribeToEvents();
    }

    private void subscribeToEvents()
    {
        AudioEvents.brickBreakSound += brickBroken;
        AudioEvents.powerUpCollectSound += powerUpCollected;
        AudioEvents.platformBounceSound += platformBounceSound;
    }

    private void brickBroken()
    {
        audioSource.clip = brickBreakSound;
        audioSource.pitch = 1f;
        audioSource.volume = 1f;
        audioSource.Play();
    }

    private void powerUpCollected()
    {
        audioSource.clip = collectPowerUpSound;
        audioSource.pitch = 1f;
        audioSource.volume = 1f;
        audioSource.Play();
    }
    private void platformBounceSound()
    {
        audioSource.clip = brickBreakSound;
        audioSource.pitch = .5f;
        audioSource.volume = .5f;

        audioSource.Play();
    }
}
