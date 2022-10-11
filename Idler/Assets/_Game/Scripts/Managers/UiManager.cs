using TMPro;
using UnityEngine;

namespace IdleGame
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager Instance;
        
        public TextMeshProUGUI BuyText;
        public int BuyMode;

        public bool IsPaused;
        
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

        private void Start()
        {
            BuyMode = 1;
            BuyText.text = BuyMode.ToString();
        }

        public void ChangeBuyMode()
        {
            switch (BuyMode)
            {
                default:
                    BuyMode = 1;
                    BuyText.text = "1";
                    break;
                case 1:
                    BuyMode = 2;
                    BuyText.text = "10";
                    break;
                case 2:
                    BuyMode = 3;
                    BuyText.text = "100";
                    break;
            }
        }
        
        
    }
   
}