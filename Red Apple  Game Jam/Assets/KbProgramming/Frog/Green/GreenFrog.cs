using UnityEngine;

public class GreenFrog : MonoBehaviour
{
    public Animator greenFrog;
    public Transform pointA;
    public Transform pointB;
    public float jumpHeight = 2f;
    public float jumpSpeed = 1f;
    public float waitTime = 1f;

    private Vector3 targetPoint;
    private bool movingToB = true;
    private bool isJumping = false;
    private float jumpProgress = 0f;
    private Vector3 startPosition;


    
    private void Start()
    {
        // Start at pointB initially
        targetPoint = pointB.position;
    }

    void Update()
    {
        NonInteractableJump();
        if (!isJumping)
        {
            JumpToTarget();
        }
        else
        {
            PerformJump();
        }
    }


    void JumpToTarget()
    {
        if (movingToB)
        {
            targetPoint = pointB.position;
            transform.localScale = new Vector3(1, 1, 1); // Face right
        }
        else
        {
            targetPoint = pointA.position;
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }

        // Check if frog is close enough to start jumping
        if (Vector3.Distance(transform.position, targetPoint) > 0.1f)
        {
            isJumping = true;
            jumpProgress = 0f;
            startPosition = transform.position;
        }
        else
        {
            // Change direction and wait before jumping again
            movingToB = !movingToB;
            Invoke(nameof(ResetJump), waitTime);
        }
    }

    void PerformJump()
    {
        jumpProgress += Time.deltaTime * jumpSpeed;
        if (jumpProgress >= 1f)
        {
            jumpProgress = 1f;
            isJumping = false;
        }

        // Calculate the current position along the parabolic path
        Vector3 currentPosition = Vector3.Lerp(startPosition, targetPoint, jumpProgress);
        float parabolicHeight = Mathf.Sin(jumpProgress * Mathf.PI) * jumpHeight; // Adjust the curve here
        transform.position = new Vector3(currentPosition.x, startPosition.y + parabolicHeight, currentPosition.z);
    }

    void ResetJump()
    {
        isJumping = false;
    }

    void NonInteractableJump()
    {
        bool nearPointA = Mathf.Abs(transform.position.x - pointA.position.x) < 0.4f;
        bool nearPointB = Mathf.Abs(transform.position.x - pointB.position.x) < 0.4f;

        if (nearPointA || nearPointB)
        {
            greenFrog.SetBool("Jump", true);
        }
        else
        {
            greenFrog.SetBool("Jump", false);
        }

    }
}
