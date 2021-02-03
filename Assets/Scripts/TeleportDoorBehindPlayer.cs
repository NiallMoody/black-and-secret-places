using UnityEngine;

/// When triggered, teleports the door to a specified distance behind the player on the z-axis.
public class TeleportDoorBehindPlayer : MonoBehaviour
{
	///	The player to grab our door's position from.
	public Transform player;
	///	The door to teleport.
	public Transform door;

	///	How far behind the player to position the door.
	public float doorDistance = 2.0f;

	///	Used to ensure we only teleport it once.
	public bool onceOnly = false;

	///	Used to ensure we only teleport it once.
	private bool done = false;

	///	Teleport our GameObject to the passed-in destination.
	public void Teleport()
	{
		if(!done)
		{
			Vector3 interludePos = door.parent.position;
			Vector3 doorPos = player.position;

			doorPos.x = 0.0f;
			doorPos.y = 2.0f;
			doorPos.z -= interludePos.z;
			doorPos.z -= doorDistance;

			door.localPosition = doorPos;

			if(onceOnly)
				done = true;
		}
	}
}
