using UnityEngine;
using UnityEngine.Events;

/// Simple class triggering a UnityEvent when its GameObject became visible to the player.
/*!
	Note: Unity counts GameObjects as visible whenever they're within the
	camera's frustrum, regardless of whether they're occluded by other objects.
	You may need to make use of the becameInvisibleEvents too to work around
	this.
 */
public class EventOnBecameVisible : MonoBehaviour
{
	///	Any events to trigger when we become visible.
	public UnityEvent becameVisibleEvents;
	///	Any events to trigger when we become invisible.
	public UnityEvent becameInvisibleEvents;

	///	Called when the GameObject became visible to the player.
	private void OnBecameVisible()
	{
		becameVisibleEvents.Invoke();
	}
	///	Called when the GameObject became invisible to the player.
	private void OnBecameInvisible()
	{
		becameInvisibleEvents.Invoke();
	}
}
