using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaxDistance : MonoBehaviour
{
    public AudioSource audioSource;
	public float maxDistance;

	public void SetValue()
	{
		audioSource.maxDistance = maxDistance;
	}
}
