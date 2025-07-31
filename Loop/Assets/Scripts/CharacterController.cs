// Jone Sainz Egea
// 31/07/2025
    // Character can move between three positions
    // Character can jump

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private int posNumber = 1;
    [SerializeField] Transform[] positions;

    [SerializeField] float jumpForce = 12f;
    [SerializeField] float fallGravity = 6f;
    [SerializeField] float lowGravity = 3f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;               
    private float groundCheckRadius = 0.1f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // TODO: make it work with WASD, INTRO SPACE AND NUM
        if (Input.GetKeyDown("right"))
        {
            posNumber++;
            Move();
        }
        if (Input.GetKeyDown("left"))
        {
            posNumber--;
            Move();
        }
        if (Input.GetKeyDown("up"))
        {
            if(isGrounded)
                Jump();
        }

        AdjustGravity();
    }

    private void Move()
    {
        posNumber = Mathf.Clamp(posNumber, 0, 2);
        // TODO: slide sound
        // TODO: slide animation
        transform.position = new Vector2 (positions[posNumber].position.x, transform.position.y);
    }

    private void Jump()
    {
        // TODO: jump sound
        // TODO: jump animation
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void AdjustGravity()
    {
        if (isGrounded)
            return;

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravity;
        }
        else if (rb.velocity.y > 0)
        {
            rb.gravityScale = lowGravity;
        }
    }
}
