using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkableCloud : MonoBehaviour
{
    [Tooltip("Delay before the player starts sinking through the cloud.")]
    [SerializeField] private float sinkDelay = 1f;

    [Tooltip("How quickly the cloud rises back up after the player leaves.")]
    [SerializeField] private float sinkingSpeed = 0.01f;

    private bool isSinking = false;
    private bool sinkingTriggered = false; // Flag to track if sinking has been triggered
    private Transform playerTransform;  // Reference to the player's transform
    private Rigidbody playerRigidbody; // Reference to the player's Rigidbody
    private Collider cloudCollider; // Reference to the cloud's collider
    private float boundaryCheckTimer = 0.5f; // Grace period timer
    private float timeOutsideCloud = 0f;    // Time spent outside the cloud
    private float boundaryCheckDelay = 5.0f; // Delay before starting boundary checks
    private float timeSinceSinkingStarted = 0f; // Time elapsed since sinking started


    // Start is called before the first frame update
    void Start()
    {
        // Get the cloud's collider
        cloudCollider = GetComponent<Collider>();
        if (cloudCollider == null)
        {
            Debug.LogError("No Collider found on the cloud!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.transform;
            playerRigidbody = playerTransform.GetComponent<Rigidbody>();

            if (!sinkingTriggered)
            {
                sinkingTriggered = true;
                Invoke(nameof(StartSinking), sinkDelay); // Start sinking after a delay
            }
        }
      
    }

    void OnCollisionExit(Collision collision)
    {
        // Stop sinking when the player leaves
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited cloud!");
            CancelInvoke(nameof(StartSinking)); // Cancel sinking if the delay hasn't finished
            sinkingTriggered = false;
            StopSinking(); // Reset sinking state
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSinking && playerTransform != null)
        {
            HandleSinkingMovement();

            // Increase the time since sinking started
            timeSinceSinkingStarted += Time.deltaTime;

            // Continuously check if the player is still within the cloud's bounds
            if (timeSinceSinkingStarted >= boundaryCheckDelay && !IsPlayerInsideCloud())
            {
                timeOutsideCloud += Time.deltaTime;
                if (timeOutsideCloud >= boundaryCheckTimer)
                {
                    Debug.Log("Player left the cloud boundary after grace period.");
                    StopSinking();
                }
            }
            else
            {
                timeOutsideCloud = 0f; // Reset timer if player returns within bounds
            }
        }
    }

    void StartSinking()
    {
        if (playerTransform == null)
        {
            Debug.Log("Player left the cloud before sinking started.");
            return; // Ensure the player is still on the cloud
        }

        Debug.Log("Player starts sinking.");
        isSinking = true;
        timeSinceSinkingStarted = 0f; // Reset sinking timer

        // Disable cloud collider to allow smooth sinking
        if (cloudCollider != null)
        {
            cloudCollider.enabled = false;
        }

        // Disable player's physics for controlled sinking
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = false; // Allow player movement input
            playerRigidbody.useGravity = false;  // Disable gravity for controlled sinking
            playerRigidbody.velocity = Vector3.zero; // Reset velocity immediately
        }
    }

     private void HandleSinkingMovement()
    {
        if (playerTransform != null)
        {
            // Apply downward sinking speed, keeping horizontal movement intact
            Vector3 velocity = playerRigidbody.velocity;
            velocity.y = -sinkingSpeed; // Override vertical velocity for sinking
            playerRigidbody.velocity = velocity;
        }
    }

    private void StopSinking()
    {
        Debug.Log("Player stops sinking.");
        isSinking = false;
        sinkingTriggered = false;

        // Re-enable cloud collider
        if (cloudCollider != null)
        {
            cloudCollider.enabled = true;
        }

        if (playerRigidbody != null)
        {
            playerRigidbody.useGravity = true;  // Re-enable gravity
            playerRigidbody.isKinematic = false; // Ensure physics is fully re-enabled
            playerRigidbody.velocity = Vector3.zero; // Reset velocity
        }

        // Delay re-enabling the cloud collider
        StartCoroutine(EnableCloudColliderWithDelay());

        playerTransform = null; // Clear the player reference
    }

    private IEnumerator EnableCloudColliderWithDelay()
    {
        yield return new WaitForSeconds(0.2f); // Delay to allow the player to move away
        if (cloudCollider != null)
        {
            Debug.Log("Re-enabling cloud collider.");
            cloudCollider.enabled = true;
        }
    }

    private bool IsPlayerInsideCloud()
    {
        if (playerTransform == null || cloudCollider == null)
        {
            return false;
        }

        // Check if the player's position is within the cloud's bounds
        Bounds expandedBounds = cloudCollider.bounds;
        expandedBounds.Expand(0.1f); // Expand the bounds slightly to avoid precision issues
        
        // Check if the player's position is within the expanded bounds
        Vector3 playerPosition = playerTransform.position;
    
        bool inside = expandedBounds.Contains(playerPosition);
        Debug.Log($"Player inside cloud bounds: {inside}");
        return inside;
    }

}
