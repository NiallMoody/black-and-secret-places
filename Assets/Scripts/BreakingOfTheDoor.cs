using UnityEngine;
using UnityEngine.Events;

/// We use this script to animate the breaking of a door.
public class BreakingOfTheDoor : MonoBehaviour
{
	///	The GameObject we'll be animating and then removing for each step of the door breaking.
	public GameObject doorObject;

	///	Array of our animation meshes.
	public Mesh[] animationMeshes;

	///	How long to wait between each animation frame.
	[Range(0.01f, 10.0f)]
	public float frameTime = 2.0f;
	///	Offset before triggering the first frame.
	[Range(0.0f, 1.0f)]
	public float firstOffset = 1.0f;

	///	An event that will be triggered when the door has completely broken.
	public UnityEvent breakingEvent;

	/// True if we're in the process of breaking.
	private bool breaking = false;
	///	Used to trigger the next step in the breaking animation.
	private float animTime = 0.0f;
	///	Our current step in the animation.
	private int animStep = 0;

	///	Update animTime to take firstOffset into account.
	private void Start()
	{
		animTime = (1.0f - firstOffset) * frameTime;
	}

	/// Where we animate the door breaking.
	private void Update()
	{
		if(breaking)
		{
			float lastTime = animTime;

			animTime += Time.deltaTime;

			if(animTime >= frameTime)
			{
				++animStep;

				switch(animStep)
				{
					case 1:
						doorObject.GetComponent<MeshFilter>().mesh = animationMeshes[0];
						break;
					case 2:
						doorObject.GetComponent<MeshFilter>().mesh = animationMeshes[1];
						break;
					case 3:
						breakingEvent.Invoke();
						doorObject.SetActive(false);
						breaking = false;
						break;
				}

				animTime = 0.0f;
			}
		}
	}

	/// We can call this to start the door breaking.
	public void TriggerBreaking()
	{
		breaking = true;
	}
}
