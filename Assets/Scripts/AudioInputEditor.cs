using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioInput))]
[CanEditMultipleObjects]
public class AudioInputEditor : Editor
{
	private int selected = 0;
	private bool showAdvanced = false;
	private bool automatic = true;
	private AudioSource audioSource;
	private int samplerateIndex = 1;
	private int bufferLength = 2;

	//TODO: Don't hardcode these values!?
	private string[] samplerateOptions = new string[] { "44100", "48000", "88200", "96000", "192000" };

	//Update our values.
	public void Awake()
	{
		string devName = serializedObject.FindProperty("device").stringValue;

		for(int i=0;i< Microphone.devices.Length;++i)
		{
			if(Microphone.devices[i] == devName)
			{
				selected = i;
				break;
			}
		}

		showAdvanced = serializedObject.FindProperty("showAdvanced").boolValue;
		automatic = serializedObject.FindProperty("automatic").boolValue;
		audioSource = (AudioSource)serializedObject.FindProperty("audioSource").objectReferenceValue;
		
		int rate = serializedObject.FindProperty("samplerate").intValue;
		for(int i=0;i<samplerateOptions.Length;++i)
		{
			if(rate == int.Parse(samplerateOptions[i]))
			{
				samplerateIndex = i;
				break;
			}
		}

		bufferLength = serializedObject.FindProperty("bufferLength").intValue;
	}

	//Draw our dropdown.
	public override void OnInspectorGUI()
	{
		//Update selected device.
		selected = EditorGUILayout.Popup(new GUIContent("Device", "The input audio device."),
										 selected,
										 Microphone.devices);
		//Update the selected choice in the underlying object
		serializedObject.FindProperty("device").stringValue = Microphone.devices[selected];


		//Update advanced options.
		showAdvanced = EditorGUILayout.BeginFoldoutHeaderGroup(showAdvanced,
															   "Advanced Options");
		if(showAdvanced)
		{
			//Draw automatic audio source toggle.
			automatic = EditorGUILayout.Toggle(new GUIContent("Automatic Audio Source",
															  "If this is checked, we'll use the Audio Source attached to this GameObject. Uncheck it if you want to use a different Audio Source."),
											   automatic);
			serializedObject.FindProperty("automatic").boolValue = automatic;

			//Draw AudioSource selector.
			if(!automatic)
			{
				audioSource = (AudioSource)EditorGUILayout.ObjectField(new GUIContent("Audio Source",
																					  "Specifies the Audio Source to use with this Audio Input."),
																	   audioSource,
																	   typeof(AudioSource),
																	   true);
				serializedObject.FindProperty("audioSource").objectReferenceValue = audioSource;
			}

			//Draw samplerate selector.
			samplerateIndex = EditorGUILayout.Popup(new GUIContent("Samplerate",
																   "The samplerate to use for the audio input."),
													samplerateIndex,
													samplerateOptions);
			serializedObject.FindProperty("samplerate").intValue = int.Parse(samplerateOptions[samplerateIndex]);

			//Draw buffer length slider.
			bufferLength = EditorGUILayout.IntSlider(new GUIContent("Buffer Length",
																	"The length (in seconds) of the internal buffer Unity will use for audio input."),
													 bufferLength,
													 1,
													 20);
			serializedObject.FindProperty("bufferLength").intValue = bufferLength;
		}
		EditorGUILayout.EndFoldoutHeaderGroup();
		serializedObject.FindProperty("showAdvanced").boolValue = showAdvanced;

		serializedObject.ApplyModifiedProperties();

		//Save the changes back to the object
		EditorUtility.SetDirty(target);
	}
}
