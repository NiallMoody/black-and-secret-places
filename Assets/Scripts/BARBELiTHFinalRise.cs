using UnityEngine;

/// Used to raise BARBELiTH to its final resting position.
public class BARBELiTHFinalRise : MonoBehaviour
{
	///	Our reference to BARBELiTH.
	public GameObject barbelith;

	///	How fast to raise BARBELiTH.
	[Range(0.01f, 1.0f)]
	public float speed = 0.05f;

	///	True if BARBELiTH is rising.
	private bool rising = false;

	///	Rises BARBELiTH.
	private void FixedUpdate()
	{
		if(rising)
		{
			if(barbelith.transform.position.y < 14.0f)
			{
				Vector3 pos = barbelith.transform.position;

				pos.y += speed;
				barbelith.transform.position = pos;

				if(pos.y > 0.0f)
				{
					Vector3 scale = barbelith.transform.localScale;

					scale.x = scale.y = scale.z = 10.0f + (Mathf.SmoothStep(0.0f, 1.0f, pos.y/14.0f) * 10.0f);
					barbelith.transform.localScale = scale;
				}
				else if(pos.y >= 12.0f)
					rising = false;
			}
		}
	}

	///	Triggers the rise.
	public void Rise()
	{
		rising = true;
	}
}
