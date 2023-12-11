using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfScript : MonoBehaviour
{
    
    [SerializeField] public float MoveSpeed = 2f;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private float direction = -1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            //Move right
            rb.velocity = new Vector2(MoveSpeed, 0f);
        } else
        {
            //move left
            rb.velocity = new Vector2(-MoveSpeed, 0f);
        }
    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)*5), transform.localScale.y);
    }




    
}
