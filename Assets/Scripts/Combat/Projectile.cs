using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float lifetime = 4f;
	public int damage = 1;
	private bool hasDealtDamage = false;

	void Start()
	{
		Destroy(gameObject, lifetime);
	}

	public void Launch(Vector3 direction, float speed)
	{
		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.velocity = direction.normalized * speed;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		HandleCollision(collision.gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		HandleCollision(other.gameObject);
	}

	private void HandleCollision(GameObject hitObject)
	{
		if (!hasDealtDamage && hitObject.CompareTag("Enemy"))
		{
			Health enemyHealth = hitObject.GetComponent<Health>();
			if (enemyHealth != null)
			{
				enemyHealth.TakeDamage(damage);
				hasDealtDamage = true;
			}
		}

		Destroy(gameObject);
	}
}
