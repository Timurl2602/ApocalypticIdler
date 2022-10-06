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

        public void Tick(float deltaTimeInSeconds)
        {
            money += CalculateProgression(deltaTimeInSeconds);
        }

        private double CalculateProgression(float deltaTimeInSeconds)
        {
            return Generators == null ? 0 : Generators.Sum(generator => generator.Produce(deltaTimeInSeconds));
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
    }
}