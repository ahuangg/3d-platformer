using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrigger : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the spikes
        animator = GetComponent<Animator>();

        // Ensure the spikes are idle at the start
        animator.SetBool("PlayerNearby", false);
    }

    void OnTriggerEnter(Collider c)
    {
        // Check if the object that triggered the collider is the player
        if (c.CompareTag("Player"))
        {
            // Set the trigger in the Animator to start the rolling animation
            animator.SetBool("PlayerNearby", true);
        }
    }

    // Detect when the player exits the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Set the bool to false to return to idle animation
            animator.SetBool("PlayerNearby", false);
        }
    }
}
