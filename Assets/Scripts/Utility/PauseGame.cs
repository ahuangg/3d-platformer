using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Pause();  // Start the game in paused mode
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))  // Toggle pause
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    // Function to pause the game
    void Pause()
    {
        Time.timeScale = 0f; // Stop the game by setting the time scale to 0
        isPaused = true;     // Set the pause state to true
    }

    // Function to resume the game
    void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game by setting the time scale to 1
        isPaused = false;    // Set the pause state to false
    }
}
