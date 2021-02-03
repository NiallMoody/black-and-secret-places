using UnityEngine;
using UnityEngine.Events;

///	Script to teleport the player when they enter a trigger volume.
public class TeleportOnEnter : MonoBehaviour
{
	///	Position to teleport to.
	public Vector3 teleportDestination;

	///	Used to trigger additional events when the player enters the trigger volume.
	public UnityEvent additionalEvents;

	///	Called when the player enters the portal.
	private void OnTriggerEnter(Collider other)
	{
		if(other.name == "Player")
		{
			other.gameObject.GetComponent<CharacterController>().enabled = false;
			other.gameObject.transform.position = teleportDestination;
			other.gameObject.GetComponent<CharacterController>().enabled = true;

			additionalEvents.Invoke();
		}
	}
}
