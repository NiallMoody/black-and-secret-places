using UnityEngine;

/// Class that deactivates an object on Start, so we can still see it in the editor, and activate it in-game.
public class DeactivateOnStart : MonoBehaviour
{
    /// Deactivate object.
    void Start()
    {
        gameObject.SetActive(false);
    }
}
