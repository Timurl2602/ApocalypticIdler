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
        
        public Hero Hero;
        public WaveManager WaveManager;
        public EnemyScriptableObject EnemyScriptable;
        public Animator Anim;
        
        [Header("Stats")]
        
        [SerializeField] private double _health;
        [SerializeField] private double _maxHealth;
        [SerializeField] private float _movementSpeed;

        
        private int _randomPosition;
        private bool _isDamageable;

        private new Vector3 _targetPosition;

        public double newHealth;
        public double MaxHealth
        {
            get { return _maxHealth; }
            set => MaxHealth = value;
        }
        
        public double Health
        {
            get { return Health; }
            set => Health = value;
        }

        /*public void Init(Hero hero, WaveManager waveManager)
        {
            
        }
        */
        private void Start()
        {
            _maxHealth = EnemyScriptable.health;
            _movementSpeed = EnemyScriptable.speed;

            Hero = GameObject.Find("Hero").GetComponent<Hero>();
            WaveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
            
            Anim = GetComponent<Animator>();
            Anim.SetBool("isRunning", true);

            CalculateEnemyHealth();
            _health = _maxHealth;

            _randomPosition = Random.Range(-8, -6);
            transform.rotation = Quaternion.Euler(0, -180, 0);
            _targetPosition = new Vector3(_randomPosition, transform.localPosition.y, 0);
        }

        private void Update()
        {
            
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
            
            if (_health <= 0)
            {
                Destroy(gameObject);
                Anim.SetBool("isDeath", true);
                WaveManager.enemiesKilled++;
                GameManager.Instance.AddMoney(50);
            }
            else
            {
                Anim.SetBool("isDeath", false);
            }

            if (transform.position == _targetPosition)
            {
                Anim.SetBool("isRunning", false);
                Anim.SetBool("isAttacking", true);
            }
            else
            {
                Anim.SetBool("isRunning", true);
            }
            
            
            
        }
        

        public void CalculateEnemyHealth()
        {
            newHealth = 100 * Math.Pow(EnemyScriptable.healthIncrease, GameManager.Instance.Wave - 1);
            _maxHealth = newHealth;
        }
        public IEnumerator TakeDamage()
        {
            while (_isDamageable)
            {
                yield return new WaitForSeconds(Hero.AttackSpeed);
                _health -= Hero.HeroDamage;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Hero"))
            {
                _isDamageable = true;
                StartCoroutine(TakeDamage());
            }
        }
    }
}
