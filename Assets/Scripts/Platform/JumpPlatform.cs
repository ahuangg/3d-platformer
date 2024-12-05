using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
	public float jumpForce = 750f;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
			if (playerRb != null)
			{
				Vector3 velocity = playerRb.velocity;
				velocity.y = 0f;
				playerRb.velocity = velocity;

				playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			}
		}
	}
}