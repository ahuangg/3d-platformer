using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
	public float elapsedTime;
	public TextMeshProUGUI timerText;
	void Start()
	{
		elapsedTime = 0f;
		UpdateTimerText();
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;
		UpdateTimerText();
	}


	void UpdateTimerText()
	{
		int hours = Mathf.FloorToInt(elapsedTime / 3600);
		int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
		int seconds = Mathf.FloorToInt(elapsedTime % 60);
		timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
	}
}
