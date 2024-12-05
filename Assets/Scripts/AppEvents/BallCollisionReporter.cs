using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionReporter : MonoBehaviour
{
    // Enable collision sound
    void OnCollisionEnter(Collision c)
    {
        // Check if the collision is strong enough to trigger an event
        if (c.impulse.magnitude > 0.5f) // Adjust the threshold as needed
        {
            // Use the first contact point to trigger the event
            EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.contacts[0].point);

        }
    }
}
