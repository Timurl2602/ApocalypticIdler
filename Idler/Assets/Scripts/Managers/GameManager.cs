using System.Collections.Generic;
using UnityEngine;


namespace IdleGame
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance;

        public List<GeneratorScriptableObject> generators;

        [Header("Wave Variables")]
        
        public float Wave;
        public float HeroDamage;
        public int AttackSpeed;
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

            // calculate
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