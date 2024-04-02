using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float walkSpeed = 1.5f;
    public bool canMove = true; // Boolean flag to control movement

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private bool isWalking;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!canMove) return; // Check if movement is allowed

        // Input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Check if Shift key is being held down
        isWalking = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Calculate movement vector
        movement.x = horizontalInput;
        movement.y = verticalInput;

        // Set animation triggers based on movement state
        if (animator != null)
        {
            animator.SetBool("Walk", isWalking && movement.sqrMagnitude > 0);
            animator.SetBool("Run", !isWalking && movement.sqrMagnitude > 0);
        }

        // Mirror character when turning
        if (movement.x < 0) // If moving left
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 1); // Flip character horizontally
        }
        else if (movement.x > 0) // If moving right
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 1); // Reset character scale
        }
    }

    private void FixedUpdate()
    {
        if (!canMove) return; // Check if movement is allowed

        // Movement
        if (!isWalking)
        {
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + movement.normalized * walkSpeed * Time.fixedDeltaTime);
        }
    }

    private void LateUpdate()
    {
        // Set idle animation only when the player stops moving completely
        if (!isWalking && movement.sqrMagnitude == 0 && animator != null)
        {
            animator.SetBool("Idle", true);
        }
        else if (animator != null) // Reset idle animation when moving
        {
            animator.SetBool("Idle", false);
        }
    }
}
