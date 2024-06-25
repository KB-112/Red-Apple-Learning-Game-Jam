using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 5f; // Desired jump height
    [SerializeField] private Transform groundCheck; // Reference to the position marking where to check if the player is grounded
    [SerializeField] private LayerMask groundLayer; // Layer mask to define what is considered ground

    private Rigidbody2D rb;
    private bool isGrounded;
    private float jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = Mathf.Sqrt(jumpHeight * -2 * Physics2D.gravity.y); // Calculate jump force based on desired height
    }

    private void Update()
    {
        PlayerMovement();
        GroundCheck();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveHorizontal(-1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveHorizontal(1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Check if player is grounded before allowing jump
        {
            Jump();
        }
    }


    void MoveHorizontal(int direction)
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }

    void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f) // Check if player is close to the ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Set isGrounded to false when jumping
        }
    }


    private void GroundCheck()
    {
        // Check if the player is grounded by casting a circle at the groundCheck position
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ensure the player is grounded when colliding with the ground
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }
}
