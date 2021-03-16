using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BARBELiTHSizeWatcher : MonoBehaviour
{
	public LibPdInstance barbelithPatch;
	public Transform barbelithTransform;

	private Vector3 lastSize;

	// Start is called before the first frame update
	void Start()
    {
        lastSize = barbelithTransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
		if(barbelithTransform.localScale != lastSize)
		{
			//1 -> 5 in first scene.
			//(previously 50 -> 40).
			barbelithPatch.SendFloat("size", barbelithTransform.localScale.x);

			lastSize = barbelithTransform.localScale;
		}
	}
}
