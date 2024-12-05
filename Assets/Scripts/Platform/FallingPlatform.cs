using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	private Vector3 initialPosition;
	private Quaternion initialRotation;
	private bool isFalling = false;

	private void Start()
	{
		initialPosition = transform.position;
		initialRotation = transform.rotation;

		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.isKinematic = true;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player") && !isFalling)
		{
			isFalling = true;
			StartCoroutine(FallAfterDelay());
		}
	}

	private System.Collections.IEnumerator FallAfterDelay()
	{
		yield return new WaitForSeconds(2f);

		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.isKinematic = false;
		}

		StartCoroutine(ResetPlatform());
	}

	private System.Collections.IEnumerator ResetPlatform()
	{
		yield return new WaitForSeconds(10f);

		transform.position = initialPosition;
		transform.rotation = initialRotation;

		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.isKinematic = true;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		isFalling = false;
	}
}
