using UnityEngine;


namespace IdleGame
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;

        public float wave;

        public float stage;

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

        public void AddMoney(double amount)
        {
            money += amount;
        }

        public void TakeMoney(double amount)
        {
            money -= amount;
        }
    }
}