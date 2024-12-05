using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
	public Animator anim;
	public Collider swordCollider;
	public float attackCooldown = 1.0f;
	private float lastAttackTime = 0.0f;
	private AudioSource audioSource;

	void Start()
	{
		anim = GetComponent<Animator>();
		swordCollider = GameObject.Find("LongSwordMesh").GetComponent<Collider>();
		swordCollider.enabled = false;
		audioSource=transform.Find("AttackSound").GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= lastAttackTime + attackCooldown)
		{
			lastAttackTime = Time.time;
			anim.SetTrigger("meleeAttack");
			audioSource.Play();
			StartCoroutine(HandleAttack());
		}
	}

	private IEnumerator HandleAttack()
	{
		swordCollider.enabled = true;
		yield return new WaitForSeconds(0.5f);
		Collider[] hitColliders = Physics.OverlapBox(swordCollider.bounds.center, swordCollider.bounds.extents, Quaternion.identity);
		foreach (Collider hit in hitColliders)
		{
			Health enemyHealth = hit.GetComponent<Health>();
			if (enemyHealth != null)
			{
				enemyHealth.TakeDamage(1);

			}
		}
		swordCollider.enabled = false;

	}
}
