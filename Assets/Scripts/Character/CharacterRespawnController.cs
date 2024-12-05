using UnityEngine;

public class CharacterRespawnController : MonoBehaviour
{
	public Transform[] respawnPoints;
	public float fallThreshold = -10f;
	private int currentRespawnIndex = 0;
	void Update()
	{
		if (transform.position.y < fallThreshold)
		{
			Respawn();
		}
	}

	void Respawn()
	{
		transform.position = respawnPoints[currentRespawnIndex].position;

		var health = GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(1);
		}
	}
}
