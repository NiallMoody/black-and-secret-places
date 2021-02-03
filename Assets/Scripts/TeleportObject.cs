using UnityEngine;

/// Simple class with a method that will teleport its object to the passed-in destination.
public class TeleportObject : MonoBehaviour
{
	///	The object to teleport.
	public Transform objectToTeleport;
	///	The position to teleport it to.
	public Vector3 destination;

    ///	Teleport our GameObject to the passed-in destination.
	public void Teleport()
	{
		objectToTeleport.position = destination;
	}
}
