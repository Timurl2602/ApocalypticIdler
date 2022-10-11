using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IdleGame
{
    public class Enemy : MonoBehaviour
    {
        [Header("References")]
        
        public WaveManager WaveManager;
        public EnemyScriptableObject EnemyScriptable;
        public Animator Anim;
        
        [Header("Stats")]
        
        [SerializeField] private double _health;
        [SerializeField] private double _maxHealth;
        [SerializeField] private float _movementSpeed;

        
        private int _randomPosition;
        [ReadOnly] private bool _isDamageable;

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
        
        private void Start()
        {
            _maxHealth = EnemyScriptable.Health;
            _movementSpeed = EnemyScriptable.Speed;
            
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
                Anim.SetBool("isDying", true);
                WaveManager.EnemiesKilled++;
                GameManager.Instance.AddMoney(50);
            }
            else
            {
                Anim.SetBool("isDying", false);
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
            newHealth = 100 * Math.Pow(EnemyScriptable.HealthIncrease, GameManager.Instance.Wave - 1);
            _maxHealth = newHealth;
        }
        public IEnumerator TakeDamage()
        {
            while (_isDamageable)
            {
                _health -= GameManager.Instance.HeroDamage;
                yield return new WaitForSeconds(GameManager.Instance.AttackSpeed);
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
