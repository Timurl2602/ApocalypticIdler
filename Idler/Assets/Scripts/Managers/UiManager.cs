using TMPro;
using UnityEngine;

namespace IdleGame
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager instance;
        
        public TextMeshProUGUI buyText;
        public int buyMode;
        
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

        private void Start()
        {
            buyMode = 1;
            buyText.text = buyMode.ToString();
        }

        public void ChangeBuyMode()
        {
            switch (buyMode)
            {
                default:
                    buyMode = 1;
                    buyText.text = "1";
                    break;
                case 1:
                    buyMode = 2;
                    buyText.text = "10";
                    break;
                case 2:
                    buyMode = 3;
                    buyText.text = "100";
                    break;
            }
        }
    }
   
}