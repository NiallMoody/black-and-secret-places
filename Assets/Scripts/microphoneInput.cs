using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microphoneInput : MonoBehaviour
{
    // Start recording with built-in Microphone and play the recorded audio right away
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("M4", true, 20, 44100);
        audioSource.Play();
    }
}
