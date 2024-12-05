using UnityEngine;
using TMPro;

public class GodModeManager : MonoBehaviour
{
	private bool isGodModeActive = false;
	public TextMeshProUGUI godModeText;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			ToggleGodMode();
			UpdateUI();
		}
	}

	private void ToggleGodMode()
	{
		isGodModeActive = !isGodModeActive;
	}

	public bool IsGodModeActive()
	{
		return isGodModeActive;
	}

	private void UpdateUI()
	{
		if (godModeText != null && isGodModeActive)
		{
			godModeText.text = "God Mode: ON";
		}
		else
		{
			godModeText.text = "";
		}
	}

}
