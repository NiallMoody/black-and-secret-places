using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BARBELiTHBlendPoints : MonoBehaviour
{
	public float radius = 1.0f;

	public LibPdInstance pdPatch;
	public string signal;

	public Transform playerPos;

	private float lastValue = 0.0f;

	private void Start()
	{
		if(pdPatch && (signal != ""))
			pdPatch.Bind(signal);
	}

	private void OnDestroy()
	{
		if(pdPatch && (signal != ""))
			pdPatch.UnBind(signal);
	}

	private void Update()
	{
		if(pdPatch && (signal != ""))
		{
			float dist = Vector3.Distance(new Vector3(playerPos.position.x, 0.0f, playerPos.position.z),
										  new Vector3(transform.position.x, 0.0f, transform.position.z));
			float value = 0.0f;

			if(dist < radius)
				value = 1.0f - (dist/radius);

			if(value != lastValue)
			{
				pdPatch.SendFloat(signal, value);

				lastValue = value;
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 0.5f);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
