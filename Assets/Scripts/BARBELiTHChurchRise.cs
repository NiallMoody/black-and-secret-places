using UnityEngine;

/// Script to make BARBELiTH rise from under the church.
public class BARBELiTHChurchRise : MonoBehaviour
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
			if(barbelith.transform.position.y < 12.0f)
			{
				Vector3 pos = barbelith.transform.position;

				pos.y += speed;
				barbelith.transform.position = pos;

				if(pos.y > 0.0f)
				{
					Vector3 scale = barbelith.transform.localScale;

					scale.x = scale.y = scale.z = 5.0f + (Mathf.SmoothStep(0.0f, 1.0f, pos.y / 12.0f) * 5.0f);
					barbelith.transform.localScale = scale;
				}
				else if(pos.y >= 12.0f)
					rising = false;
			}
		}
	}

	///	Triggers the rise.
	private void OnTriggerEnter(Collider other)
	{
		if((other.name == "Player") && (barbelith.transform.position.y < 12.0f))
		{
			rising = true;

			SphereCollider col = barbelith.GetComponents<SphereCollider>()[1];

			col.radius = 0.0f;
		}
	}
}
