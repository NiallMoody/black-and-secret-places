using UnityEngine;

///	Script to set BARBELiTH to fall when the player enters a trigger volume.
public class BARBELiTHFallTrigger : MonoBehaviour
{
	///	Our reference to BARBELiTH.
	public GameObject barbelith;

	///	Hide BARBELiTH at start (this lets us keep it visible in the editor).
	private void Start()
	{
		barbelith.GetComponent<MeshRenderer>().enabled = false;
	}

	///	We trigger BARBELiTH to fall when the player enters the trigger volume.
	private void OnTriggerEnter(Collider other)
	{
		barbelith.GetComponent<MeshRenderer>().enabled = true;
		barbelith.GetComponent<Rigidbody>().useGravity = true;
	}
}
