using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObj : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Player")
        {
            Die();
        }
    }
    private void Die()
    {
        
        Destroy(gameObject);
        Debug.Log("destroyedObject");
        
    }
}
