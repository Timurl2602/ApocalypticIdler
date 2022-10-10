using System;
using IdleGame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShopItem : MonoBehaviour
{
        [Header("References")]

        [SerializeField] private GeneratorScriptableObject _upgrade;
        [SerializeField] private TextMeshProUGUI _upgradeNameText;
        [SerializeField] private TextMeshProUGUI _upgradeCostText;
        [SerializeField] private TextMeshProUGUI _ownedText;

        [SerializeField] private int _buyAmount = 1;
        
        //[SerializeField] public Image icon;

        private void Start()
        {
            _upgrade.Owned = 1;
            ShopInterface();
        }
        

        private void Update()
        {
            ShopInterface();
            _upgrade.UpgradeAmount = _buyAmount;
            _upgrade.UpdateGeneratorCost();
            _buyAmount = UiManager.Instance.BuyMode switch
            {
                1 => 1,
                2 => 10,
                3 => 100,
                _ => _buyAmount
            };
            
        }
        
        

        public void BuyUpgrade()
        {
            if (GameManager.Instance.Money >= _upgrade.CostForNextUpgrade)
            {
                _upgrade.UpdateGeneratorCost();
                GameManager.Instance.TakeMoney(_upgrade.CostForNextUpgrade);
                _upgrade.Owned += _upgrade.UpgradeAmount;
            }

        }

        private void ShopInterface()
        {
            _upgradeNameText.text = _upgrade.UpgradeName;
            _upgradeCostText.text = string.Format((_upgrade.CostForNextUpgrade < 1000) ? "{0:F2}" : "{0:0.00e0}", _upgrade.CostForNextUpgrade) + "$";
            _ownedText.text = "Owned: " + _upgrade.Owned;
        }
        
        
        
        

}
