using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 5.0f;
    public float attackCooldown = 1.0f;
    private float lastAttackTime = 0.0f;
    public Animator anim;

    private Mana manaSystem;
    private const int manaCost = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        manaSystem = GetComponent<Mana>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= lastAttackTime + attackCooldown)
        {
            if (manaSystem != null && manaSystem.mana >= manaCost)
            {
                lastAttackTime = Time.time;
                anim.SetTrigger("rangedAttack");

                FireProjectile();
                manaSystem.Consume(manaCost);
            }
        }
    }

    private void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.Launch(firePoint.forward, projectileSpeed);
    }
}
