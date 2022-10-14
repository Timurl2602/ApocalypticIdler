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
        public EnemyHealthbar Healthbar;
        
        [Header("Stats")]
        
        [SerializeField] private double _health;
        [SerializeField] private double _maxHealth;
        [SerializeField] private float _movementSpeed;


        private int _randomPosition;
        [ReadOnly] private bool _isDamageable;

        private new Vector3 _targetPosition;

        public double newHealth;

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
            _movementSpeed = Random.Range(2, 5);

            _randomPosition = Random.Range(-8, -5);
            transform.rotation = Quaternion.Euler(0, -180, 0);
            _targetPosition = new Vector3(_randomPosition, transform.localPosition.y, 0);
        }

        private void Update()
        {
            
            Healthbar.SetHealth((float)_health, (float)_maxHealth);
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
            
            if (_health <= 0)
            {
                Destroy(gameObject);
                Anim.SetBool("isDying", true);
                WaveManager.EnemiesKilled++;
                GameManager.Instance.AddMoney(GameManager.Instance.MoneyOnKill);
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
                Healthbar.SetHealth((float)_health, (float)_maxHealth);
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
