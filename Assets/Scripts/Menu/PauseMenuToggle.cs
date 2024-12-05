using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Note that Input.GetKeyUp() should eventually be replaced with Input.GetButtonUp() with a 
 * virtual button created in the InputManager settings. This will allow multiple game controllers 
 * to map to common input events (e.g. simultaneous keyboard, and handheld game controller 
 * support).
 */
[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour
{
	private CanvasGroup canvasGroup;
    void Awake()
    {
        // Attempt to get the CanvasGroup component
		canvasGroup = GetComponent<CanvasGroup>();

		// Log an error if CanvasGroup is not found
		if (canvasGroup != null)
		{
			Debug.LogError("CanvasGroup component not found on the GameObject", this);
		}
    }

    // Update is called once per frame
    void Update()
    {
		// Check if the Escape key is released
		if (Input.GetKeyUp(KeyCode.Escape))
		{	
			// Toggle the menu based on its current interactable state
			if (canvasGroup.interactable)
			{	
				// in-game menu is off
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
				canvasGroup.alpha = 0f;
				Time.timeScale = 1f; // Resume time
			}
			else
			{	
				// in-game menu is visible
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
				canvasGroup.alpha = 1f;
				Time.timeScale = 0f; // Pause time
			}
		}
	}
}