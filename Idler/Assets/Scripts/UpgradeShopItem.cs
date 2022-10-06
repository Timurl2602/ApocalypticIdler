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
    

        //[SerializeField] public Image icon;

        private void Start()
        {
            ShopInterface();
        }

        public void BuyUpgrade()
        {
            if (GameManager.instance.Money >= upgrade.costForNextUpgrade)
            {
                upgrade.UpdateGeneratorCost();
                GameManager.instance.TakeMoney(upgrade.costForNextUpgrade);
                upgrade.owned++;
                ShopInterface();
            }

        }

        private void ShopInterface()
        {
            upgradeNameText.text = upgrade.upgradeName;

            upgradeCostText.text = upgrade.costForNextUpgrade.ToString("f2");

            ownedText.text = "Owned: " + upgrade.owned;

        }
        

}
