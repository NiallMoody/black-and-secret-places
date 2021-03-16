using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BARBELiTHOcclusion : MonoBehaviour
{
	public Transform player;
	public Transform barbelith;
	public LibPdInstance barbelithPatch;

	private float occlusion = 0.0f;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
		float occluded = 1.0f;

		if(Physics.Raycast(player.position,
						   barbelith.position - player.position,
						   out hit,
						   Mathf.Infinity))
		{
			if(hit.transform == barbelith)
			{
				occluded = 0.0f;
			}
		}

		if(occlusion != occluded)
		{
			barbelithPatch.SendFloat("occlusion", occluded);

			Debug.Log("Sent occlusion: " + occluded);

			occlusion = occluded;
		}
	}
}
