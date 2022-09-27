using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;  //Reference for character controller
    public Transform cam; //Reference to the camera.

    [SerializeField] private int playerIndex;
    public float speed = 6f;   //Speed variable.
    Vector3 velocity; //Velocity variable.
    bool isGrounded;  //Variable to use to see if the player is grounded or not.
    public float gravity = -9.81f;  //Sets the gravity.
    public float jumpHeight = 3f;  //Sets the jumpheight.

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float turnSmoothTime = 0.1f; //Variable that adjusts the turning so it's more smooth. Without this it snaps instantly when it turns.
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (ActivePlayerManager.GetInstance().IsItMyTurn(playerIndex))
        {

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float horizontal = Input.GetAxisRaw("Horizontal"); //Input check for horizontal inputs.
            float vertical = Input.GetAxisRaw("Vertical"); //Input check for vertical inputs.
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //Stores direction.

            if (Input.GetButtonDown("Jump") && isGrounded)  //Asks if the player has pressed space and if they're not in the air.

            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (direction.magnitude >= 0.1f) //A check to see if the player is moving.
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //Points the player to the direction that they are moving.
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //Uses the direction to figure out how much the player should rotate on the Y axis.
                transform.rotation = Quaternion.Euler(0f, angle, 0f); //Sets the rotation.

                Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward; //Makes the player move in the direction that they are moving.
                controller.Move(moveDir.normalized * speed * Time.deltaTime); //Determines how fast the player is going.
            }

        }
    }

    public int GetIndex()
    {
        return playerIndex;
    }
}
