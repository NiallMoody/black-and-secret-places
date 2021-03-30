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
		float occluded = 0.0f;
        RaycastHit hit;

		if(Physics.Raycast(player.position,
						   barbelith.position - player.position,
						   out hit,
						   Mathf.Infinity))
		{
			if(hit.transform == barbelith)
			{
				occluded += 1.0f;
			}
		}

		for(int i=0;i<16;++i)
		{
			Vector3 pos = barbelith.position;

			if (Physics.Raycast(player.position,
							    pos - player.position,
							    out hit,
							    Mathf.Infinity))
			{
				if (hit.transform == barbelith)
				{
					occluded += 1.0f;
				}
			}
		}

		occluded /= 17.0f;
		occluded = 1.0f - occluded;

		if(occlusion != occluded)
		{
			barbelithPatch.SendFloat("occlusion", occluded);

			Debug.Log("Sent occlusion: " + occluded);

			occlusion = occluded;
		}
	}
}
