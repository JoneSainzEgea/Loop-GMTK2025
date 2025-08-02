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
    private Animator anim;
    private bool isGrounded;

    private void OnEnable()
    {
        ObstacleCollider.OnPlayerHit += PlayHitAnimation;
    }

    private void OnDisable()
    {
        ObstacleCollider.OnPlayerHit -= PlayHitAnimation;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // TODO: make it work with WASD, INTRO SPACE AND NUM
        if (Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D))
        {
            posNumber++;
            Move();
        }
        if (Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.A))
        {
            posNumber--;
            Move();
        }
        if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
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
        anim.SetTrigger("slide");
        transform.position = new Vector2 (positions[posNumber].position.x, transform.position.y);
    }

    private void Jump()
    {
        // TODO: jump sound
        anim.SetTrigger("jump");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void PlayHitAnimation()
    {
        anim.SetTrigger("hit");
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
