using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Animator Anim;

    [ReadOnly] public int count;

    private void Start()
    {
        Anim = GetComponent<Animator>();
        count = 0;
    }

    private void Update()
    {
        if (count <= 0)
        {
            Anim.SetBool("isAttacking", false);
        }
    }
    /*private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Anim.SetBool("isAttacking", true);
        }
        else
        {
            Anim.SetBool("isAttacking", false);
        }
    }*/
    
    void OnTriggerEnter2D(Collider2D other ) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Anim.SetBool("isAttacking", true);
            ++count;
        }
    }
 
    void OnTriggerExit2D(Collider2D other ) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            --count;
        }
    }
    
    
}
