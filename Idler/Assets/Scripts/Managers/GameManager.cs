using UnityEngine;


namespace IdleGame
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance;

        [Header("Wave Variables")]
        
        public float Wave;
        public float Stage;

        [SerializeField] private double _money;
        public double Money
        {
            get { return _money; }
            set => _money = value;
        }

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

        public void AddMoney(double amount)
        {
            _money += amount;
        }

        public void TakeMoney(double amount)
        {
            _money -= amount;
        }
    }
}