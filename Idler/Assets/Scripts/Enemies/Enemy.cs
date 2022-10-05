using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public Hero hero;

        public EnemyScriptableObject enemy;

        [SerializeField] private int health;

        [SerializeField] private int maxHealth;
        public int MaxHealth
        {
            get { return maxHealth; }
            set => MaxHealth = value;
        }

        [SerializeField] private bool isDamageable = false;

        [SerializeField] private float movementSpeed;

        private void Start()
        {
            maxHealth = enemy.Health;
            movementSpeed = enemy.Speed;
            health = maxHealth;
            hero = GameObject.Find("Hero").GetComponent<Hero>();
        }

        private void Update()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-9,Random.Range(-9, 9f),0), movementSpeed * Time.deltaTime);
        
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
            isDamageable = true;
            StartCoroutine(TakeDamage());
            Debug.Log(health);
        }
    }
}
