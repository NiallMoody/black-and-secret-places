using UnityEngine;

/// Class to quit when the player hits escape (for builds).
public class EscapeToQuit : MonoBehaviour
{
	private void Update()
	{
		if(Input.GetButtonDown("Quit"))
			Application.Quit();
	}
}
