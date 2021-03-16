using UnityEngine;
using UnityEngine.Events;

/// Script handling the rising of BARBELiTH and it's stone circle.
public class BARBELiTHRise : MonoBehaviour
{
	///	Our reference to BARBELiTH.
	public GameObject barbelith;
	///	Our reference to the stone ring to raise with BARBELiTH.
	public GameObject stoneCircle;
	///	Our reference to the ground to trigger when BARBELiTH starts to rise.
	public GameObject hiddenGround;

	///	How fast to raise BARBELiTH.
	[Range(0.01f, 1.0f)]
	public float speed = 0.05f;

	///	So we can trigger the BreakingOfTheDoor script when we're done.
	public UnityEvent onFinish;

	///	True if BARBELiTH is rising.
	private bool rising = false;

	///	Used to rise BARBELiTH.
	private void FixedUpdate()
	{
		if(rising)
		{
			if(barbelith.transform.position.y < 10.0f)
			{
				Vector3 pos = barbelith.transform.position;

				pos.y += speed;
				barbelith.transform.position = pos;

				if(pos.y >= 10.0f)
				{
					rising = false;
					onFinish.Invoke();
				}
				else if(pos.y > 0.0f)
				{
					Vector3 scale = barbelith.transform.localScale;

					scale.x = scale.y = scale.z = 1.0f + (Mathf.SmoothStep(0.0f, 1.0f, pos.y/10.0f) * 4.0f);
					barbelith.transform.localScale = scale;
				}
			}

			if(stoneCircle.transform.position.y < 1.0f)
			{
				Vector3 pos = stoneCircle.transform.position;

				pos.y += speed;
				stoneCircle.transform.position = pos;
			}
		}
	}

	///	Used to start BARBELiTH rising.
	private void OnTriggerEnter(Collider other)
	{
		if((other.name == "BARBELiTH") && !rising)
		{
			barbelith.GetComponent<BARBELiTHKick>().enabled = false;
			barbelith.GetComponent<Rigidbody>().isKinematic = true;

			Vector3 pos = barbelith.transform.position;

			pos.x = 150.0f;
			pos.y = -3.0f;
			pos.z = -110.0f;
			barbelith.transform.position = pos;

			stoneCircle.SetActive(true);

			hiddenGround.SetActive(true);

			rising = true;
		}
	}
}
