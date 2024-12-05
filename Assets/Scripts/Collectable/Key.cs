using UnityEngine;
using TMPro;
using System.Collections;

public class Key : MonoBehaviour
{
	public int keys;
	public TextMeshProUGUI keyText;
	public TextMeshProUGUI announcementText;
	public GameObject targetObject;


	void Start()
	{
		keys = 0;
		UpdateUI();
	}

	public void AddKey(int key)
	{
		keys += key;
		UpdateUI();
		ShowRemainingKeys();

		if (keys >= 3 && targetObject != null)
		{
			Destroy(targetObject);
		}
	}

	private void UpdateUI()
	{
		if (keyText != null)
		{
			keyText.text = keys.ToString("D3");
		}
	}

	private void ShowRemainingKeys()
	{
		StartCoroutine(DisplayKeyCount());
	}

	IEnumerator DisplayKeyCount()
	{
		int remainingKeys = 3 - keys;
		announcementText.enabled = true;
		if (remainingKeys == 0)
		{
			announcementText.text = "All keys collected! Gate to Dragon has been destroyed!";
		}
		else
		{
			announcementText.text = $"You found a key, there are {remainingKeys} key{(remainingKeys > 1 ? "s" : "")} remaining";
		}

		yield return new WaitForSeconds(3f);

		announcementText.enabled = false;
	}
}
