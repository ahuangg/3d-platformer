using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
     [Tooltip("The speed of the cloud's movement.")]
    [SerializeField] private float moveSpeed = 1f;

    [Tooltip("Simulated wind direction affecting cloud movement.")]
    [SerializeField] private Vector3 windDirection = new Vector3(1f, 0f, 0f);

    [Tooltip("GameObject defining the movement boundary.")]
    [SerializeField] private GameObject boundaryObject;

    private Vector3 targetPosition; // The next random position to move towards
    private Bounds movementBounds; // The movement bounds derived from the boundaryObject

    // Start is called before the first frame update
    void Start()
    {
        if (boundaryObject != null)
        {
            // Get the bounds from the boundary object's collider or transform
            Collider boundaryCollider = boundaryObject.GetComponent<Collider>();
            if (boundaryCollider != null)
            {
                movementBounds = boundaryCollider.bounds;
            }
            else
            {
                Debug.LogError("Boundary Object must have a Collider component!");
            }

            // Set an initial random target position within the bounds
            SetRandomTargetPosition();
        }
        else
        {
            Debug.LogError("Boundary Object is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (boundaryObject == null) return;
        
        MoveCloud();
        transform.Rotate(Vector3.up, 10f * Time.deltaTime); // Adjust speed as needed
    }

    private void MoveCloud()
    {
        Vector3 adjustedTarget = targetPosition + windDirection * moveSpeed * Time.deltaTime;
        // Move the cloud towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // If the cloud reaches the target position, set a new random target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    private void SetRandomTargetPosition()
    {
        if (boundaryObject == null) return;

        // Generate a random position within the bounds
        float randomX = Random.Range(movementBounds.min.x, movementBounds.max.x);
        float randomY = Random.Range(movementBounds.min.y, movementBounds.max.y);
        float randomZ = Random.Range(movementBounds.min.z, movementBounds.max.z);

        targetPosition = new Vector3(randomX, randomY, randomZ);

        Debug.Log($"New target position set: {targetPosition}");
    }

    private void OnDrawGizmosSelected()
    {
        if (boundaryObject != null)
        {
            // Draw the boundary box in the Scene view
            Gizmos.color = Color.blue;
            Collider boundaryCollider = boundaryObject.GetComponent<Collider>();
            if (boundaryCollider != null)
            {
                Gizmos.DrawWireCube(boundaryCollider.bounds.center, boundaryCollider.bounds.size);
            }
        }
    }
}
