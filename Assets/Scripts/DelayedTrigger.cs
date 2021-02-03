using UnityEngine;
using UnityEngine.Events;

/// Simple class that triggers an event/events after a delay.
public class DelayedTrigger : MonoBehaviour
{
	///	The delay to wait before triggering (in seconds).
	public float delay = 1.0f;

    ///	Events to trigger.
	public UnityEvent eventsToTrigger;

	///	Used to measure how long we've delayed so far.
	private float index = 0.0f;
	///	True if we've been triggered.
	bool triggered = false;

	///	Where we wait.
	private void Update()
	{
		if(triggered)
		{
			index += Time.deltaTime/delay;

			if(index >= delay)
			{
				eventsToTrigger.Invoke();

				triggered = true;
			}
		}
	}

	///	Starts the process.
	public void TriggerDelay()
	{
		if(!triggered)
		{
			index = 0.0f;
			triggered = true;
		}
	}
}
