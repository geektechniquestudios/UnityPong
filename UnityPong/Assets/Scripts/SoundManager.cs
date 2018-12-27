using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Holds the single instance of the SoundManager
    // that can be accessed from any other script
    public static SoundManager Instance = null;

    // Will hold the sound effects
    public AudioClip goalBloop;
    public AudioClip lossBuzz;
    public AudioClip hitPaddleBloop;
    public AudioClip winSound;
    public AudioClip wallBloop;

    private AudioSource soundEffectAudio;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;

    }

    // Any script can call this to play a sound effect
    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}