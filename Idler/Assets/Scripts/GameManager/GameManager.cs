using System;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace IdleGame
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;

        public GeneratorScriptableObject[] Generators;

        [SerializeField]
        private double money;
        public double Money
        {
            get { return money; }
            set => money = value;
        }

        private void Awake() 
        {

            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddMoney(int amount)
        {
            money += amount;
        }

        public void TakeMoney(int amount)
        {
            money -= amount;
        }
    }
}