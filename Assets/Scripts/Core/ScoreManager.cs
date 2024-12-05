using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public GameObject player;
	public TimeManager timeManager;
	public GameObject dragon;

	private const int maxScore = 1000;
	private const int timeLimit = 600;
	private const int timePenalty = 10;

	private void Update()
	{
		if (dragon == null)
		{
			CalculateScore();
		}
	}

	private void CalculateScore()
	{
		float timeTaken = timeManager.elapsedTime;
		int remainingHealth = player.GetComponent<Health>().health;

		int score = maxScore;

		if (timeTaken > timeLimit)
		{
			score -= Mathf.RoundToInt((timeTaken - timeLimit) / timePenalty);
		}

		score = Mathf.Max(0, score + (remainingHealth * 100));
		UpdateUI(score);
	}

	private void UpdateUI(int score)
	{
		if (scoreText != null)
		{
			scoreText.text = "Game Won!! Score: " + score.ToString();
		}
	}
}
