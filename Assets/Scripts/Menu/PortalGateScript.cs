using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalGateScript : MonoBehaviour
{
	// Specify the name of the scene to load.
	public string sceneToLoad = "GameScene";

	private void OnTriggerEnter(Collider other)
	{
		// Check if the object entering the trigger is the player (by tag or name)
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player has entered the portal.");
			// Load the specified scene
			SceneManager.LoadScene(sceneToLoad);
		}
	}
}

