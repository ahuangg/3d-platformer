using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBallMovement : MonoBehaviour
{
    public float forceMagnitude = 1f; // The force applied to the ball (make it small for slow movement)
    public float interval = 3f;       // Time between random movements

    private Rigidbody rb;
    private float timeSinceLastForce = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody attached to the ball
    }

    void Update()
    {
        timeSinceLastForce += Time.deltaTime;

        if (timeSinceLastForce > interval)
        {
            ApplyRandomForce();
            timeSinceLastForce = 0f;  // Reset the timer after applying force
        }
    }

    // Function to apply a small random force to the ball
    void ApplyRandomForce()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            0f,  // Ensure no vertical movement
            Random.Range(-1f, 1f)
        ).normalized;

        // Apply a slow random force in a random direction
        rb.AddForce(randomDirection * forceMagnitude, ForceMode.Impulse);
    }
}
