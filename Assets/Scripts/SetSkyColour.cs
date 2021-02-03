using UnityEngine;

///	Script to set the sky colour when the player enters the void.
public class SetSkyColour : MonoBehaviour
{
	///	Called to set the sky colour to black.
	public void SetSkyToBlack()
	{
		GetComponent<Camera>().backgroundColor = Color.black;
	}
	///	Called to set the sky colour to red.
	public void SetSkyToRed()
	{
		GetComponent<Camera>().backgroundColor = Color.red;
	}
	///	Called to set the sky colour to white.
	public void SetSkyToWhite()
	{
		GetComponent<Camera>().backgroundColor = Color.white;
	}
}
