using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
	[Header("General Setting")]
	[SerializeField] private bool canUse = false;
	[SerializeField] private MenuController menuController;

	[Header("Brightness Setting")]
	[SerializeField] private Slider brightnessSlider = null;
	[SerializeField] private TMP_Text brightnessTextValue = null;

	[Header("Quality Level Setting")]
	[SerializeField] private TMP_Dropdown qualityDropdown;
	
	[Header("Fullscreen Setting")]
	[SerializeField] private Toggle fullScreenToggle;

	[Header("Sensitivity Setting")]
	[SerializeField] private TMP_Text controllerSenTextValue = null;
	[SerializeField] private Slider controllerSenSlider = null;

	[Header("Invert Y Setting")]
	[SerializeField] private Toggle invertYToggle = null;

	private void Awake()
	{
		if (canUse)
		{
			
			if (PlayerPrefs.HasKey("masterQuality"))
			{
				int localQuality = PlayerPrefs.GetInt("masterQuality");
				qualityDropdown.value = localQuality;
				QualitySettings.SetQualityLevel(localQuality);
			}

			if (PlayerPrefs.HasKey("masterFullscreen"))
			{
				int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");

				if (localFullscreen == 1)
				{
					Screen.fullScreen = true;
					fullScreenToggle.isOn = true;
				}
				else
				{
					Screen.fullScreen = false;
					fullScreenToggle.isOn = false;

				}

			if (PlayerPrefs.HasKey("masterBrightness"))
				{
					float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

					brightnessTextValue.text = localBrightness.ToString("0.0");
					brightnessSlider.value = localBrightness;
				}
			}

			if (PlayerPrefs.HasKey("masterSen"))
			{
				float localSensitivity = PlayerPrefs.GetFloat("masterSen");

				controllerSenTextValue.text = localSensitivity.ToString("0");
				controllerSenSlider.value = localSensitivity;
				menuController.mainControllerSen = Mathf.RoundToInt(localSensitivity);
			}

			if (PlayerPrefs.HasKey("masterInvertY"))
			{
				if (PlayerPrefs.GetInt("masterInvertY") == 1)
				{
					invertYToggle.isOn = true;
				}
				else
				{
					invertYToggle.isOn = false;	
				}
			}
		}
	}
}
