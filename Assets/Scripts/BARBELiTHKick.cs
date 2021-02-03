using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BARBELiTHKick : MonoBehaviour
{
	///	Our reference to BARBELiTH.
	public GameObject barbelith;

	///	How hard to kick it.
	[Range(1.0f, 2048.0f)]
	public float kickStrength = 1024.0f;

	/// Where BARBELiTH is being kicked to.
	public Vector3 destination;

	///	True once we've been kicked once.
	private bool beenKicked = false;
	/// Used to prevent re-kicking it too soon.
	private float kickWait = 0.0f;

	/// Used to prevent re-kicking it too soon.
	private void Update()
	{
		if(kickWait > 0.0f)
		{
			kickWait -= Time.deltaTime;
			if(kickWait < 0.0f)
				kickWait = 0.0f;
		}
	}

	///	Apply extra gravity once it's been kicked.
	private void FixedUpdate()
	{
		if(beenKicked)
			barbelith.GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
	}

	///	We kick BARBELiTH when the player enters the trigger volume.
	private void OnTriggerEnter(Collider other)
	{
		if(kickWait <= 0.0f)
		{
			if(other.gameObject.name == "Player")
			{
				Vector3 force = (destination - transform.position).normalized * kickStrength;
				barbelith.GetComponent<Rigidbody>().AddForce(force);

				Collider[] colliders = GetComponents<Collider>();

				for(int i=0;i<colliders.Length;++i)
				{
					if(colliders[i].material.name == "BARBELiTH Bounce (Instance)")
					{
						barbelith.GetComponent<Rigidbody>().drag = 1.2f;

						break;
					}
				}

				kickWait = 2.0f;
				beenKicked = true;
			}
		}
	}
}
