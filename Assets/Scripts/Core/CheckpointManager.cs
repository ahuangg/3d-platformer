using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
	public Transform checkpoint1;
	public Transform checkpoint2;
	public Transform checkpoint3;
	public Transform player; 
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			TeleportToCheckpoint(checkpoint1);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			TeleportToCheckpoint(checkpoint2);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			TeleportToCheckpoint(checkpoint3);
		}
	}

	private void TeleportToCheckpoint(Transform checkpoint)
	{
		player.position = checkpoint.position;
		player.rotation = checkpoint.rotation;
	}
}
