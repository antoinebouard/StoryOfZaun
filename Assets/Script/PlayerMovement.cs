using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;
    public bool isDuck;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Joystick joystick;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;

    void Update() {       
        
        if (verticalMovement >= .6f && isGrounded)
        {
            isJumping = true;
        }       

        if (verticalMovement <= -.6f)
        {
            isDuck = true;
            animator.SetBool("isDuck", true);
        } else {
            isDuck = false;
            animator.SetBool("isDuck", false);
        }

        if (!isGrounded) {
            animator.SetBool("isJumping", true);
        } else {
             animator.SetBool("isJumping", false);
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {      
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        if (joystick.Horizontal >= .2f && !isDuck) {
            horizontalMovement = joystick.Horizontal * moveSpeed * Time.deltaTime;
        } else if (joystick.Horizontal <= -.2f && !isDuck) {
            horizontalMovement = joystick.Horizontal * moveSpeed * Time.deltaTime;
        } else {
            horizontalMovement = 0;
        }     
        verticalMovement = joystick.Vertical;
        MovePlayer(horizontalMovement);      
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        } else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
