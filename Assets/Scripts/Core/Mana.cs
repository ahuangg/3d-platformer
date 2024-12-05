using UnityEngine;
using TMPro;

public class Mana : MonoBehaviour
{
	private const int MAX_MANA = 3;
	public int mana;
	public GameObject[] emptyManaImages;
	public GameObject[] fullManaImages;

	void Start()
	{
		mana = MAX_MANA;
		UpdateUI();
	}

	public void Consume(int amount)
	{
		if (mana >= amount)
		{
			mana -= amount;
			UpdateUI();
		}
	}

	public void Recharge(int amount)
	{
		mana += amount;
		if (mana > MAX_MANA)
		{
			mana = MAX_MANA;
		}
		UpdateUI();
	}

	private void UpdateUI()
	{
		for (int i = 0; i < MAX_MANA; i++)
		{
			if (i < mana)
			{
				fullManaImages[i].SetActive(true);
				emptyManaImages[i].SetActive(false);
			}
			else
			{
				fullManaImages[i].SetActive(false);
				emptyManaImages[i].SetActive(true);
			}
		}
	}
}
