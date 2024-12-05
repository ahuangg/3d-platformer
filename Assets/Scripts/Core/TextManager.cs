using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
	public TextMeshProUGUI keyText;
	public string defaultMessage = "";

	private void Start()
	{
		keyText.alignment = TextAlignmentOptions.Center;
		keyText.text = "Welcome to MonsterMashup! Your mission is to navigate the platforms, collect 3 keys to unlock the boss and defeat the final boss\nControls:WASD to move, SPACE to jump";
	}

	private void OnTriggerEnter(Collider other)
	{
		keyText.alignment = TextAlignmentOptions.Center;
		keyText.color = Color.yellow;
		switch (other.gameObject.name)
		{
			case "TutorialTrigger":
				keyText.text = "Welcome to MonsterMashup! Your mission is to navigate the platforms, collect 3 keys to unlock the boss and defeat the final boss\nControls:WASD to move, SPACE to jump";
				break;
			case "CollectableTrigger":
				keyText.text = "Collect coins to gain more points! Destroy crates to reveal items such as coins, health potions, mana potions, and keys";
				break;
			case "ObstacleTrigger":
				keyText.text = "Careful! Dodge these moving obstacles and avoid stepping on unstable or damage platforms";
				break;
			case "CombatTrigger":
				keyText.text = "There are enemies ahead! Defeat them to while navigating platforms. \n Combat Controls: LEFT CLICK/E to melee attack, Q to range attack.";
				break;
			case "DefaultTrigger":
				keyText.text = "";
				break;
		}
	}

}