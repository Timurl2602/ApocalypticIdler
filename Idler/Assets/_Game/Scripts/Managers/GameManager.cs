using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;


namespace IdleGame
{
    public class GameManager : MonoBehaviour
    {

        [Header("References")]
        public static GameManager Instance;
        public List<GeneratorScriptableObject> generators;
        public GameObject Coin;

        [Header("Wave Variables")]
        public float Wave;

        [Header("Hero Variables")]
        public float BaseHeroDamage;
        public float HeroDamage;
        public int AttackSpeed;
        
        [Header("Player Variables")]
        public double Money;
        public bool HasAttackBuff;

        private void Awake() 
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SpawnRandom();
            }
            
        }

        private void OnEnable()
        {
            EventManager.OnBuy += OnBuy;
        }

        private void OnDisable()
        {
            EventManager.OnBuy -= OnBuy;
        }
        
        private void OnBuy(string upgradeName, int upgradeAmount)
        {
            var generator = generators.Find(x => x.UpgradeName == upgradeName);
            if (generator == null)
                return;

            generator.Owned += upgradeAmount;
            generator.UpdateGeneratorCost();
            
            var damageCalculation = BaseHeroDamage * Mathf.Pow(generator.UpgradeIncrease, generator.Owned);
            HeroDamage = damageCalculation;

            Debug.Log(damageCalculation);
        }
        
        public void SpawnRandom()
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 12), Random.Range(-4, 3), -5);
            Instantiate(Coin,randomPosition,Quaternion.identity);
        }
        
        public void AddMoney(double amount)
        {
            Money += amount;
        }

        public void TakeMoney(double amount)
        {
            Money -= amount;
        }
    }
}