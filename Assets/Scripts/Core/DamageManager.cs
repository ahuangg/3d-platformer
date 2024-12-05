using UnityEngine;

using UnityEngine;

public class DamageManager : MonoBehaviour
{
	public int damageAmount = 1;

	private void OnCollisionEnter(Collision collision)
	{
		ApplyDamage(collision.gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		ApplyDamage(other.gameObject);
	}

	private void ApplyDamage(GameObject target)
	{
		var health = target.GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(damageAmount);
		}
	}
}
