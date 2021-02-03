using UnityEngine;
using UnityEngine.Events;

/// Simple class triggering a UnityEvent when the player enters a trigger volume.
public class EventOnEnter : MonoBehaviour
{
	///	Any events to trigger.
	public UnityEvent triggerEvents;

	///	Restrict activating objects to the ones with these names.
	public GameObject[] allowedObjects;

	///	Where we invoke triggerEvents.
	private void OnTriggerEnter(Collider other)
	{
		if(allowedObjects.Length < 1)
			triggerEvents.Invoke();
		else
		{
			for(int i=0;i<allowedObjects.Length;++i)
			{
				if(other.name == allowedObjects[i].name)
				{
					triggerEvents.Invoke();
					break;
				}
			}
		}
	}
}
