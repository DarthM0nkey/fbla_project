using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 5f;

    private CharacterController characterController;
    private bool isGrounded;
    private Vector3 playerVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Rotate the movement direction to match the camera rotation
        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0f;

        // Move the player
        if (characterController.isGrounded)
        {
            playerVelocity = direction * (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);
        }

        playerVelocity.y += Physics.gravity.y * Time.deltaTime;

        // Apply movement
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    void HandleJump()
    {
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        isGrounded = hit.normal.y > 0.9f;
    }
}

