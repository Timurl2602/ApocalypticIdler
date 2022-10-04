using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Hero hero;
    
    [SerializeField] private int health;

    [SerializeField] private int maxHealth;
    
    [SerializeField] private float loopTime;

    [SerializeField] private bool isDamageable = false;
    
    [SerializeField] private Vector3 targetPosition;

    [SerializeField] private float movementSpeed;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        
        Debug.Log(health);
    }

    public IEnumerator TakeDamage()
    {
        while (isDamageable)
        {
            yield return new WaitForSeconds(loopTime);
            health -= hero.HeroDamage;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isDamageable = true;
        StartCoroutine(TakeDamage());
        Debug.Log(health);
    }
}
