using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public GameObject player; // Reference to the player
    private Rigidbody rb; // Rigidbody for physics
    public float speed = 10f; // Base speed for movement
    public float rotationSpeed = 5f; // Speed of rotation towards player

    private bool shouldFollow = false; // Tracks if the enemy should follow the player

    private void Start()
    {
        // Initialize Rigidbody
        rb = GetComponent<Rigidbody>();

        // Debugging: Ensure Rigidbody is properly set
        if (rb == null)
        {
            Debug.LogError("Rigidbody is not assigned or missing!");
        }
    }

    private void Update()
    {
        // Check if the player has been detected
        if (PlayerDetection.found)
        {
            shouldFollow = true;
            Debug.Log("Player detected!");
        }

        // Rotate to face the player
        if (shouldFollow)
        {
            // Smoothly rotate towards the player
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        // Move toward the player
        if (shouldFollow)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Apply velocity directly to move the enemy toward the player
            rb.linearVelocity = direction * speed;

            // Debugging: Log velocity to check if it's being applied
            Debug.Log("Velocity: " + rb.linearVelocity);
        }
    }
}
