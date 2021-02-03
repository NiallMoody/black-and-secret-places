using UnityEngine;
using UnityEngine.Events;

/// Script to tween the scale of an object over a period of time when triggered.
public class TweenScale : MonoBehaviour
{
	/// The object to re-scale.
	public Transform objectToScale;

	/// The destination scale of the object.
	public Vector3 destinationScale;

	/// How long the tween should last.
	public float time;

	/// Used to trigger something else once the tween is finished.
	public UnityEvent finished;

	///	Whitelist of objects which can trigger us.
	public GameObject[] allowedObjects;

	///	Our object's scale when we started the tween.
	private Vector3 startScale;
	/// Where we are in the tween.
	private float index = 0.0f;
	///	True if we are currently tweening.
	private bool tweening = false;

    /// Where we handle the tweening.
    void Update()
    {
		if(tweening)
		{
			index += Time.deltaTime/time;

			objectToScale.localScale = Vector3.Lerp(startScale,
													destinationScale,
													Mathf.SmoothStep(0.0f,
																	 1.0f,
																	 index));

			if(index >= 1.0f)
			{
				tweening = false;
				finished.Invoke();
			}
		}
	}

	///	Start tweening when something enters our trigger volume.
	private void OnTriggerEnter(Collider other)
	{
		if(!tweening)
		{
			bool startTweening = false;

			if(allowedObjects.Length < 1)
				startTweening = true;
			else
			{
				for(int i=0;i<allowedObjects.Length;++i)
				{
					if(other.name == allowedObjects[i].name)
					{
						startTweening = true;
						break;
					}
				}
			}

			if(startTweening)
			{
				startScale = objectToScale.localScale;
				tweening = true;
			}
		}
	}
}
