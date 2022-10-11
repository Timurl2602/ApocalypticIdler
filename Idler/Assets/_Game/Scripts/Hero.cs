using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Anim.SetBool("isAttacking", true);
        }
        else
        {
            Anim.SetBool("isRunning", false);
        }
    }
}
