using System;
using System.Collections.Generic;
using UnityEngine;


namespace IdleGame
{
    public class GameManager : MonoBehaviour
    {

        [Header("References")]
        public static GameManager Instance;
        public List<GeneratorScriptableObject> generators;

        [Header("Wave Variables")]
        public float Wave;

        [Header("Hero Variables")]
        public float BaseHeroDamage;
        public float HeroDamage;
        public int AttackSpeed;
        
        [Header("Player Variables")]
        public double Money;

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

            generator.Owned++;
            generator.UpdateGeneratorCost();
            
            var damageCalculation = BaseHeroDamage * Mathf.Pow(generator.UpgradeIncrease, generator.Owned);
            HeroDamage = damageCalculation;

            Debug.Log(damageCalculation);
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