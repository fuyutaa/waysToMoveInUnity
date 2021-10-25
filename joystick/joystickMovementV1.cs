using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// version with rb.MovePosition, so you can't send any velocity to your animator :/
public class JoystickMovement : MonoBehaviour
{
    public MovementJoystick movementJoystick; // referencing the joystick so we can get its public Vec value, that we'll use to move or not.
    public float moveSpeed;
    private Rigidbody2D rb;
    
    Vector3 m_velocity = Vector3.zero;
    Vector2 targetVelocity;
    Vector3 velocity;

    Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(movementJoystick.joystickVec.y != 0)
        {
            targetVelocity = new Vector2(movementJoystick.joystickVec.x * moveSpeed, movementJoystick.joystickVec.y * moveSpeed);
            rb.MovePosition(rb.position + targetVelocity * moveSpeed * Time.fixedDeltaTime);

            animator.SetFloat("Speed", rb.velocity.magnitude);
        }
        else
        {
            rb.velocity = m_velocity; // if the joystick is released, the velocity is setted to zero so the player don't move.
        }
    }
}