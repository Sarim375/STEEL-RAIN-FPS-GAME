using UnityEngine;

using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 10f;
    public float sensitivity = 5f;
    public float jumpForce = 15f;

    [Header("References")]
    public Camera cam;

    private Rigidbody rb;
    private float cameraVerticalAngle = 0f; // Tracks the camera's vertical angle

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevents unintended physics-based rotation
    }

    private void Update()
    {
        // Use Update for input handling
        PlayerMovement();
        PlayerRotation();
    }

    void PlayerMovement()
    {

        float movX = Input.GetAxis("Horizontal"); // Smooth input for better movement
        float movY = Input.GetAxis("Vertical");

        // Calculate direction relative to the player
        Vector3 moveDirection = transform.right * movX + transform.forward * movY;

        // Apply movement
        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))

        {
            //JUMP

            rb.AddForce(Vector3.up * jumpForce);


        }
    }
        void PlayerRotation()
        {
            // Horizontal rotation (Y-axis) for the player
            float rotateY = Input.GetAxis("Mouse X") * sensitivity;
            transform.Rotate(0, rotateY, 0);

            // Vertical rotation (X-axis) for the camera
            float rotateX = Input.GetAxis("Mouse Y");
            cameraVerticalAngle -= rotateX * sensitivity; // Invert mouse Y
            cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -90f, 90f); // Clamp vertical angle

            // Apply clamped rotation to the camera
            cam.transform.localEulerAngles = new Vector3(cameraVerticalAngle, 0f, 0f);
        }
    }
