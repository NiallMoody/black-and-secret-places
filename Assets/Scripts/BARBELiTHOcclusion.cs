using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BARBELiTHOcclusion : MonoBehaviour
{
	public Transform player;
	public Transform barbelith;
	public LibPdInstance[] pdPatches;

	public bool occlusionActive = false;

	private float occlusion = 0.0f;

    // Update is called once per frame
    void Update()
    {
		if(occlusionActive)
		{
			float occluded = 0.0f;
			RaycastHit hit;
			Vector3 dir = (barbelith.position - player.position).normalized;

			if(Physics.Raycast(player.position,
							   barbelith.position - player.position,
							   out hit,
							   Mathf.Infinity))
			{
				if(hit.transform == barbelith)
				{
					occluded += 1.0f;
					Debug.DrawLine(player.position, barbelith.position, Color.yellow);
				}
				else
					Debug.DrawLine(player.position, hit.point, Color.blue);
			}

			float mult = 1.0f;

			if(player.position.z > barbelith.position.z)
				mult = -1.0f;

			for(int i=0;i<16;++i)
			{
				float angle = ((float)i/16.0f) * 2.0f * Mathf.PI;
				Vector3 pos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0.0f);

				pos *= barbelith.localScale.x * 0.49f;

				pos = Quaternion.FromToRotation(Vector3.forward * mult, dir) * pos;

				pos += barbelith.position;

				if (Physics.Raycast(player.position,
								   pos - player.position,
								   out hit,
								   Mathf.Infinity))
				{
					if(hit.transform == barbelith)
					{
						occluded += 1.0f;
						Debug.DrawLine(player.position, pos, Color.yellow);
					}
					else
						Debug.DrawLine(player.position, hit.point, Color.blue);
				}
			}

			occluded /= 17.0f;
			occluded = 1.0f - occluded;

			if(occlusion != occluded)
			{
				for(int i=0;i<pdPatches.Length;++i)
				{
					if(pdPatches[i].gameObject.activeInHierarchy)
						pdPatches[i].SendFloat("occlusion", occluded);
				}

				occlusion = occluded;
			}
		}
	}

	public void SetOcclusionActive(bool val)
	{
		occlusionActive = val;
		if(!occlusionActive)
		{
			for(int i = 0; i < pdPatches.Length; ++i)
			{
				if(pdPatches[i].gameObject.activeInHierarchy)
					pdPatches[i].SendFloat("occlusion", 0.0f);
			}
		}
	}
}
