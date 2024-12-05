using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class Patrol : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator myanimatin;

    public float distance;
    public GameObject[] waypoints;
    public int currentWP;
    public State minionstate;

    public enum State {
        still,
        moving
    };

    void Start()
    {
        minionstate = State.still;
        agent = GetComponent<NavMeshAgent>();
        myanimatin = GetComponent<Animator>();
        currentWP = -1;
        setWP();
    }

void Update()
{
    if (!agent.pathPending && agent.remainingDistance < 0.1f)
    {
        setWP();
    }

    float normalizedVelocity = agent.velocity.magnitude / agent.speed;
    myanimatin.SetFloat("vely", normalizedVelocity);

    switch (minionstate)
    {
        case State.still:
            if (currentWP >= waypoints.Length)
            {
                minionstate = State.moving;
            }
            break;

        case State.moving:
            distance = Vector3.Distance(agent.transform.position, waypoints[currentWP].transform.position);

            if (distance < 0.5f)
            {
                minionstate = State.still;
            }
            break;

        default:
            break;
    }
}

private void setWP() {
    if (waypoints.Length == 0) {
        Debug.LogError("No waypoints available.");
        return;
    }

    currentWP = (currentWP + 1) % waypoints.Length;
    Vector3 nextPosition = waypoints[currentWP].transform.position;
    agent.SetDestination(nextPosition);
}


}