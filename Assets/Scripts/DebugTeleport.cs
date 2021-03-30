using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTeleport : MonoBehaviour
{
    public Transform playerTransform;
	public GameObject barbelith;

	public TeleportOnEnter[] teleports;

	// Update is called once per frame
	void Update()
    {
		int index = -1;

        if(Input.GetKeyDown("1"))
			index = 0;
		else if (Input.GetKeyDown("2"))
		{
			index = 1;

			barbelith.GetComponent<MeshRenderer>().enabled = true;
			barbelith.GetComponent<Rigidbody>().useGravity = true;
			barbelith.GetComponent<BARBELiTHKick>().enabled = false;
			barbelith.GetComponent<Rigidbody>().isKinematic = true;
			barbelith.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
		}
		else if (Input.GetKeyDown("3"))
			index = 2;
		else if (Input.GetKeyDown("4"))
			index = 3;
		else if (Input.GetKeyDown("5"))
			index = 4;
		else if (Input.GetKeyDown("6"))
			index = 5;
		else if (Input.GetKeyDown("7"))
			index = 6;

		if (index > -1)
		{
			playerTransform.gameObject.GetComponent<CharacterController>().enabled = false;
			playerTransform.position = teleports[index].teleportDestination;
			playerTransform.gameObject.GetComponent<CharacterController>().enabled = true;

			teleports[index].additionalEvents.Invoke();
		}
	}
}
