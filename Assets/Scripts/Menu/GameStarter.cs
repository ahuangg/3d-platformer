using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
	public void StartGame()
	{
		// Be aware that Time.timeScale is preserved after loading a new level.
		Time.timeScale = 1f; // Resume time
		SceneManager.LoadScene("GameScene");
	}
}