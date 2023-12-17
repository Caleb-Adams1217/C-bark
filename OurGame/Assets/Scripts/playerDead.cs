using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDead : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private playerMovement pm;
    
    // Start is called before the first frame update
    private void Start()
    {
        anim  = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Die();
           
            Debug.Log("dead");
        }
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
    private void Restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
