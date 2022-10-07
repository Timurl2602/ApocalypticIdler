using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace IdleGame
{
    public class Enemy : MonoBehaviour
    {
        [Header("References")]
        
        public Hero hero;
        public WaveManager waveManager;
        public EnemyScriptableObject enemy;
        public Animator anim;
        
        [Header("Stats")]
        
        [SerializeField] private double health;
        [SerializeField] private double maxHealth;
        [SerializeField] private float movementSpeed;

        
        private int randomPosition;
        private bool isDamageable;

        private new Vector3 targetPosition;

        public double newHealth;
        public double MaxHealth
        {
            get { return maxHealth; }
            set => MaxHealth = value;
        }
        
        

        private void Start()
        {
            maxHealth = enemy.health;
            movementSpeed = enemy.speed;
            health = maxHealth;
            
            hero = GameObject.Find("Hero").GetComponent<Hero>();
            waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
            
            anim = GetComponent<Animator>();
            anim.SetInteger("RunIndex", Random.Range(0,3));
           //anim.SetTrigger("Run");
            anim.SetBool("isRunning", true);

            CalculateEnemyHealth();

            randomPosition = Random.Range(-9, -6);
            transform.rotation = Quaternion.Euler(0, -180, 0);
            targetPosition = new Vector3(randomPosition, transform.localPosition.y, 0);
        }

        private void Update()
        {
            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            
            if (health <= 0)
            {   
                GameManager.instance.AddMoney(50);
                waveManager.enemiesKilled++;
                Destroy(gameObject);
                
                anim.SetInteger("DeathIndex", Random.Range(0,1));
                anim.SetTrigger("Death");
            }

            if (transform.position == targetPosition)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
                anim.SetBool("isAttacking", true);
            }
            
            
            
        }
        

        public void CalculateEnemyHealth()
        {
            newHealth = 100 * Math.Pow(enemy.healthIncrease, GameManager.instance.wave - 1);
            maxHealth = newHealth;
        }
        public IEnumerator TakeDamage()
        {
            while (isDamageable)
            {
                yield return new WaitForSeconds(hero.AttackSpeed);
                health -= hero.HeroDamage;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Hero"))
            {
                isDamageable = true;
                StartCoroutine(TakeDamage());
            }
        }
    }
}
