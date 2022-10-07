using System;
using IdleGame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShopItem : MonoBehaviour
{
        [Header("References")]

        [SerializeField] public GeneratorScriptableObject upgrade;
        [SerializeField] public TextMeshProUGUI upgradeNameText;
        [SerializeField] public TextMeshProUGUI upgradeCostText;
        [SerializeField] public TextMeshProUGUI ownedText;

        [SerializeField] public int buyAmount = 1;
        
        //[SerializeField] public Image icon;

        private void Start()
        {
            upgrade.owned = 1;
            ShopInterface();
        }
        

        private void Update()
        {
            ShopInterface();
            upgrade.upgradeAmount = buyAmount;
            upgrade.UpdateGeneratorCost();
            buyAmount = UiManager.instance.buyMode switch
            {
                1 => 1,
                2 => 10,
                3 => 100,
                _ => buyAmount
            };
            
        }
        
        

        public void BuyUpgrade()
        {
            if (GameManager.instance.Money >= upgrade.costForNextUpgrade)
            {
                upgrade.UpdateGeneratorCost();
                GameManager.instance.TakeMoney(upgrade.costForNextUpgrade);
                upgrade.owned += upgrade.upgradeAmount;
            }

        }

        private void ShopInterface()
        {
            upgradeNameText.text = upgrade.upgradeName;
            upgradeCostText.text = string.Format((upgrade.costForNextUpgrade < 1000) ? "{0:F2}" : "{0:0.00e0}", upgrade.costForNextUpgrade) + "$";
            ownedText.text = "Owned: " + upgrade.owned;
        }
        
        
        
        

}
