using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Movement speeds
    public float moveSpeed = 5f;
    public float walkSpeed = 1.5f;

    // Boolean flag to control movement
    public bool canMove = true;

    // References to UI panels
    public PanelController inventoryController;
    public PanelController shopManager;

    // Rigidbody and Animator components
    private Rigidbody2D rb;
    private Animator animator;

    // Boolean flag to track walking state
    private bool isWalking;

    // Screen boundaries
    private float minX, maxX, minY, maxY;

    private void Start()
    {
        // Get Rigidbody and Animator components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Calculate screen boundaries
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minX = min.x;
        maxX = max.x;
        minY = min.y;
        maxY = max.y;
    }

    private void Update()
    {
        // Check if movement is allowed based on UI panel states
        if (!shopManager.panel.activeInHierarchy && !inventoryController.panel.activeInHierarchy)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    private void FixedUpdate()
    {
        if (!canMove) return; // Check if movement is allowed

        // Input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Check if Shift key is being held down
        isWalking = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Apply movement speed
        float speed = isWalking ? walkSpeed : moveSpeed;
        Vector2 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;

        // Clamp position to stay within screen boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Move the player
        rb.MovePosition(newPosition);

        // Set animation triggers based on movement state
        if (animator != null)
        {
            animator.SetBool("Walk", isWalking && movement.sqrMagnitude > 0);
            animator.SetBool("Run", !isWalking && movement.sqrMagnitude > 0);
            animator.SetBool("Idle", movement.sqrMagnitude == 0);
        }

        // Mirror character when turning
        if (movement.x < 0) // If moving left
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 1); // Flip character horizontally
        }
        // Reset character scale if moving right
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 1);
        }
    }
}
