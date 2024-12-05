using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
	void OnTriggerEnter(Collider c)
	{
		if (c.attachedRigidbody != null)
		{
			if (c.CompareTag("Player"))
			{
				Collect(c.gameObject);
			}
		}
	}
	private void Collect(GameObject player)
	{
		switch (gameObject.tag)
		{
			case "HealthPotion":
				Health playerHealth = player.GetComponent<Health>();
				if (playerHealth != null)
				{
					playerHealth.Heal(1);
				}
				break;
			case "ManaPotion":
				Mana playerMana = player.GetComponent<Mana>();
				if (playerMana != null)
				{
					playerMana.Recharge(1);
				}
				break;
			case "Coin":
				Coin coin = player.GetComponent<Coin>();
				if (coin != null)
				{
					coin.AddCoin(1);
				}
				break;
			case "Key":
				Key key = player.GetComponent<Key>();
				if (key != null)
				{
					key.AddKey(1);
				}
				break;
			default:
				break;
		}

		Destroy(gameObject);
	}
}
