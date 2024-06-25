using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private Vector3 moveDirection = Vector3.zero;  
    private CharacterController controller;        
          

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                moveDirection += transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection -= transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -Player().rotationSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, Player().rotationSpeed * Time.deltaTime, 0);
            }

            moveDirection = moveDirection.normalized * Player().playerSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = Player().playerJumpSpeed;
            }
        }

        moveDirection.y -= Player().playerGravity* Time.deltaTime;

        if (!controller.isGrounded)
        {
            moveDirection.y -= 2f;
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    public PlayerComponents Player()
    {
        return GameManager.Instance.playerComponents;
    }
}
