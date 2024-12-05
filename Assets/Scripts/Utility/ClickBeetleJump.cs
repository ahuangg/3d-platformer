using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBeetleJump : MonoBehaviour
{

    private Rigidbody rb;
    public float jumpForce = 5f;
    public float torqueForce = 2f;
    public float minJumpTime = 1f;
    public float maxJumpTime = 3f;
    private bool isGrounded;
    private float nextJumpTime; // Time at which the next jump can occur


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the rigidbody component
        
        // Set the initial time for the first jump
        nextJumpTime = Time.time + Random.Range(minJumpTime, maxJumpTime);
    }

    // FixedUpdate is called at a fixed interval for physics calculations
    void FixedUpdate()
    {
        // Check if the beetle is grounded and the time is right for the next jump
        if (isGrounded && Time.time > nextJumpTime)
        {
            Jump();

            // Set the time for the next jump
            nextJumpTime = Time.time + Random.Range(minJumpTime, maxJumpTime);
        }
    }

    // Jump function that adds force to the beetle
    void Jump()
    {
        if (isGrounded)
        {
            // Add force to the beetle
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // Add torque to the beetle
            rb.AddTorque(Random.insideUnitSphere * torqueForce, ForceMode.Impulse);
        }
        // Call the Jump function again after a random time
        Invoke("Jump", Random.Range(minJumpTime, maxJumpTime));
    }

    // Check if the beetle is grounded
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    // Check if the beetle is not grounded
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
