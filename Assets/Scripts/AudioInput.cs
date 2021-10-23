using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[AddComponentMenu("Audio/Audio Input")]
public class AudioInput : MonoBehaviour
{
	///	Our device selector.
	[SerializeField]
	private string device;

	///	Not sure why this is necessary...
	[SerializeField]
	private bool showAdvanced = false;

	///	If true, grab our AudioSource from our parent GameObject.
	[SerializeField]
	private bool automatic = true;

	///	The AudioSource we'll be feeding our audio to.
	[SerializeField]
	private AudioSource audioSource;

	/// The samplerate of the input device.
	[SerializeField]
	private int samplerate = 48000;

	/// Length of the buffer in seconds.
	[SerializeField]
	private int bufferLength = 1;

    void Start()
    {
        if(automatic)
			audioSource = GetComponent<AudioSource>();

		audioSource.clip = Microphone.Start(device,
											true,
											bufferLength,
											samplerate);
		audioSource.Play();

		//This is solely to hide the warning about a variable that's declared
		//but not used. We only use showAdvanced to retain the user's most
		//recent Advanced Options setting in the inspector.
		bool temp = showAdvanced;
		showAdvanced = temp;
    }
}
