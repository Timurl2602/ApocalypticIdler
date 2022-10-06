using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IdleGame
{
    public class Enemy : MonoBehaviour
    {
        [Header("References")]
        
        public Hero hero;
        public WaveManager waveManager;
        public EnemyScriptableObject enemy;
        
        [Header("Stats")]
        
        [SerializeField] private double health;
        [SerializeField] private double maxHealth;
        [SerializeField] private float movementSpeed;
        
        private bool isDamageable;

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
            CalculateEnemyHealth();
        }

        private void Update()
        {
            if (health <= 0)
            {   
                GameManager.instance.AddMoney(50);
                waveManager.enemiesKilled++;
                Destroy(gameObject);
            }
            
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-9,Random.Range(-9, 9f),0), movementSpeed * Time.deltaTime);
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
