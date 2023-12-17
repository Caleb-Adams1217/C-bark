using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] public float JumpHight = 14f;
    private float Doublejump = 1f;
    [SerializeField] public float MoveSpeed = 7f;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirx = 0f;
    public bool IsDead = false;

    private enum MovementState { idle, running, jumping, falling }
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        IsDead = GetComponent<playerDead>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * MoveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpHight);
                Doublejump = 1f;
            }
            else if (Input.GetButtonDown("Jump") && Doublejump > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpHight);
                Doublejump = Doublejump - 1f;

            }
        


        

        AnimatorUpdator();
    }

    private void AnimatorUpdator()
    {
        MovementState state;
        

        if (rb.velocity.x > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (rb.velocity.x < 0f)
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
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
