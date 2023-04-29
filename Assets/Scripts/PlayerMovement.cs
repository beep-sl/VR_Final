using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dX = 0f;

    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState
    {
        idle, running, jumping, falling
    }

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 14);
        }

        UpdateAnimationState();
       
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        } else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
            anim.SetInteger("state", (int) state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
