using UnityEngine;
using UnityEngine.Events;

/// Class to lock the player camera (and tween from it's current direction).
public class TweenLockPlayerCamera : MonoBehaviour
{
    ///	The transform controlling the players left-right rotation.
	public Transform XRotation;
	///	The transform controlling the players up-down rotation.
	public Transform YRotation;

	///	Destination left-right rotation (euler angles).
	public Vector3 destinationX;
	///	Destination up-down rotation (euler angles).
	public Vector3 destinationY;

	/// How long the tween should last.
	public float time;

	///	Our object's rotation when we started the tween.
	private Vector3 startX;
	///	Our object's rotation when we started the tween.
	private Vector3 startY;
	/// Where we are in the tween.
	private float index = 0.0f;
	///	True if we are currently tweening.
	private bool tweening = false;

	/// Where we handle the tweening.
	private void Update()
	{
		if(tweening)
		{
			index += Time.deltaTime/time;

			Vector3 rot = Vector3.Lerp(startX, destinationX, index);
			XRotation.eulerAngles = rot;

			rot = Vector3.Lerp(startY, destinationY, index);
			YRotation.eulerAngles = rot;

			if(index >= 1.0f)
				tweening = false;
		}
	}

	///	Starts the tween.
	public void StartTween()
	{
		tweening = true;
		startX = XRotation.eulerAngles;
		startY = YRotation.eulerAngles;
	}
}
