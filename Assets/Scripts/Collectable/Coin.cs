using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
	public int coins;
	public TextMeshProUGUI coinText;

	void Start()
	{
		coins = 0;
		UpdateUI();
	}

	public void AddCoin(int coin)
	{
		coins += coin;
		UpdateUI();
	}

	private void UpdateUI()
	{
		if (coinText != null)
		{
			coinText.text = coins.ToString("D3");
		}
	}

}