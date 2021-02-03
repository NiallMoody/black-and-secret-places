using UnityEngine;

/// Simple script to set the rotation of a transform when triggered.
public class SetTransformRotation : MonoBehaviour
{
    ///	The transform to rotate.
	public Transform transformToRotate;
	///	The value to set the transform's rotation to.
	public Vector3 rotation;

	///	Sets the transform's rotation.
	public void SetRotation()
	{
		transformToRotate.eulerAngles = rotation;
	}
}
