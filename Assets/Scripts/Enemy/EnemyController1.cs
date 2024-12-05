using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Estates1 { CHASE, DEAD }

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController1 : MonoBehaviour
{
    private Estates eStates;
    private NavMeshAgent enemy;
    private Animator myanim;

    public float RadiusofEnemy;
    public bool Guard;
    private float speed;
    private GameObject TargettoAttack;

    bool Walk;
    bool Chase;
    bool Follow;

    private Vector3 PositiontoGuard;

    // Initialization happens in Awake for all necessary components and values
    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        myanim = GetComponent<Animator>();
        speed = enemy.speed;   
        PositiontoGuard = transform.position;
    }

    // Main update loop
    void Update()
    {
        SwitchEnemyStates();  // Handle transitions between states
        SwitchEnemyAnimation();  // Synchronize animations based on state
    }

    // Handles setting the animation state based on movement states
    void SwitchEnemyAnimation()
    {
        myanim.SetBool("Walk", Walk);
        myanim.SetBool("Chase", Chase);  
        myanim.SetBool("Follow", Follow);    
    }

    // Switches the state of the enemy based on conditions
    void SwitchEnemyStates()
    {
        if (FoundthePlayer())
        {
            eStates = Estates.CHASE;

        }

        switch (eStates)
        {
            case Estates.CHASE:
                HandleChaseState();
                break;

            case Estates.DEAD:
                HandleDeadState();
                break;
        }
    }


    // Handles the logic when in CHASE state
    void HandleChaseState()
    {
        Walk = false;
        Chase = true;
        enemy.speed = speed;

        if (!FoundthePlayer())
        {
            Follow = false;
            enemy.destination = transform.position;
        }
        else
        {
            Follow = true;
            enemy.isStopped = false;
            enemy.destination = TargettoAttack.transform.position;
        }

        if (TargetInkRangetoAttack())
        {
            Follow = false;
            enemy.isStopped = true;
            Attack();
        }
    }

    // Placeholder for future dead state logic
    void HandleDeadState()
    {
        // Add dead state logic here if necessary
    }

    // Finds the player within the enemy's detection radius
    bool FoundthePlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, RadiusofEnemy);
        foreach (var target in colliders)
        {
            if (target.CompareTag("Player"))
            {
                TargettoAttack = target.gameObject;
                return true;
            }
        }
        TargettoAttack = null;
        return false;
    }

    // Checks if the target is within attack range
    bool TargetInkRangetoAttack()
    {
        if (TargettoAttack != null)
        {
            return Vector3.Distance(TargettoAttack.transform.position, transform.position) <= 6f;
        }
        return false;
    }

    // Triggers the attack animation if the target is in range
    void Attack()
    {
        transform.LookAt(TargettoAttack.transform);
        if (TargetInkRangetoAttack())
        {
            myanim.SetTrigger("Attack");
        }
    }
}