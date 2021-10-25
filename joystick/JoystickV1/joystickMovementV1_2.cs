/*
CONTENTS :
- WORKS WITH THE JOYSTICK I MADE! PLEASE USE THE CORRESPONDING RESSOURCES SO IT WORKS CORRECTLY 
(for example, it calls joystickVec witch is in "MovementJoystick", attached to the joystick). 
    - rb.MovePosition system
    - Animator's "Speed" value setter to 1 or 0 for running anim
    - Flip sprite on the X axis depending on joystickVec.x
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovementV1_2 : MonoBehaviour
{
    public MovementJoystick movementJoystick; // referencing the joystick so we can get its public Vec value, that we'll use to move or not.
    public float moveSpeed;
    private Rigidbody2D rb;
    
    Vector3 m_velocity = Vector3.zero;
    Vector2 targetVelocity;
    Vector3 velocity;

    Animator animator;
    SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(movementJoystick.joystickVec.y != 0)
        {
            targetVelocity = new Vector2(movementJoystick.joystickVec.x * moveSpeed, movementJoystick.joystickVec.y * moveSpeed);
            rb.MovePosition(rb.position + targetVelocity * moveSpeed * Time.fixedDeltaTime);

            animator.SetFloat("Speed", 1f); // start running anim
        }
        else
        {
            rb.velocity = m_velocity; // if the joystick is released, the velocity is setted to zero so the player don't move.
            animator.SetFloat("Speed", 0f); // stop running anim
        }

        Flip(movementJoystick.joystickVec.x);
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}