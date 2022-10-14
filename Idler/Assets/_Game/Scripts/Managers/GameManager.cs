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
        public int Wave;

        [Header("Hero Variables")]
        public float BaseHeroDamage;
        public float HeroDamage;
        public int AttackSpeed;

        public float MoneyOnKillBase;
        public float MoneyOnKill;

        [Header("Player Variables")]
        public double Money;

        private string _moneyString;
        private string _tempMoneyString;

        [Header("Player Variables")] 
        public bool PlinkoCanBePlayed;

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
            
            _tempMoneyString = PlayerPrefs.GetString("money");
            Money = double.Parse(_tempMoneyString, System.Globalization.CultureInfo.InvariantCulture);

            Wave = PlayerPrefs.GetInt("wave");
        }

        private void Start()
        {
            MoneyOnKill = MoneyOnKillBase;
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

            switch (upgradeName)
            {
                case "AttackUpgrade":
                    var damageCalculation = BaseHeroDamage * Mathf.Pow(generator.UpgradeIncrease, generator.Owned);
                    HeroDamage = damageCalculation;
                    break;
                case "AttackspeedUpgrade":
                    var attackSpeedCalculation = AttackSpeed; 
                    AttackSpeed = attackSpeedCalculation;
                    break;
                case "CurrencyIncreaseUpgrade":
                    var moneyOnKillCalculation = MoneyOnKillBase * Mathf.Pow((float)1.1, generator.Owned - 1);
                    MoneyOnKill = moneyOnKillCalculation;
                    Debug.Log(MoneyOnKill);
                    break;
            }
        }
        
        public void SpawnRandom()
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 12), Random.Range(-4, 3), -5);
            Instantiate(Coin,randomPosition,Quaternion.identity);
        }
        
        public void AddMoney(double amount)
        {
            Money += amount;
            _moneyString = Money.ToString();
            PlayerPrefs.SetString("money", _moneyString);
        }

        public void TakeMoney(double amount)
        {
            Money -= amount;
            _moneyString = Money.ToString();
            PlayerPrefs.SetString("money", _moneyString);
        }
        
        public void ResetPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}