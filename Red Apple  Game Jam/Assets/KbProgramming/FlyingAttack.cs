using UnityEngine;

public class FlyingAttack : MonoBehaviour
{
    public float attackRange = 5f; // Adjust as needed
    public float attackSpeed = 5f; // Speed of the bird when attacking
    public float birdSpeed = 3f; // Speed of the bird's movement
    public Transform player; // Reference to the player's transform
    public float returnDistance = 10f; // Distance threshold to return to original position

    private Vector3 originalPosition; // Store original position
    private SpriteRenderer spriteRenderer; // Reference to the sprite renderer

    void Start()
    {
        originalPosition = transform.position; // Store original position at start
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer component
    }

    void Update()
    {
        Vector3 targetPosition = player.position;

        // Calculate distance to player
        float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);

        if (distanceToPlayer <= attackRange)
        {
            // Player is within attack range, attack the player
            AttackPlayer(targetPosition);
        }
        else if (distanceToPlayer > returnDistance)
        {
            // Player is out of return distance, return to original position
            ReturnToOriginalPosition();
        }
        else
        {
            // Player is between attack range and return distance, move away from player
            MoveAwayFromPlayer(targetPosition);
        }
    }

    void AttackPlayer(Vector3 targetPosition)
    {
        // Flip the bird's sprite horizontally towards the player
        if (targetPosition.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        // Move towards player
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, attackSpeed * Time.deltaTime);
    }

    void MoveAwayFromPlayer(Vector3 targetPosition)
    {
        // Move away from player by calculating a direction vector away from the player's position
        Vector3 moveDirection = (transform.position - targetPosition).normalized;
        transform.position += moveDirection * birdSpeed * Time.deltaTime;

        // Flip sprite based on movement direction
        if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    void ReturnToOriginalPosition()
    {
        // Move back to original position
        transform.position = Vector3.MoveTowards(transform.position, originalPosition, birdSpeed * Time.deltaTime);

        // Reset rotation to original direction when bird reaches original position
        if (transform.position == originalPosition)
        {
            spriteRenderer.flipX = false;
        }
    }
}
