using UnityEngine;


namespace IdleGame
{
    [CreateAssetMenu(fileName ="Generator", menuName = "Utility/Generator", order = 0)]
    public class GeneratorScriptableObject : ScriptableObject
    {
        
        [Header("Upgrade Variables")]
        
        public string UpgradeName;
       
        public int Owned;
        public int UpgradeAmount;
        
        public double BaseCost;
        public double CostForNextUpgrade;
        
        public float CostIncrease;




        public void UpdateGeneratorCost()
        {
            //calculation for generator costs
            var calcTop = Mathf.Pow(CostIncrease, Owned);
            var calcBottom = Mathf.Pow(CostIncrease, Owned + UpgradeAmount);

            CostForNextUpgrade = BaseCost + (calcTop - calcBottom) / (1 - CostIncrease);
        }

        private void Precalculate()
        {
            UpdateGeneratorCost();
        }

        
        private void OnValidate()
        {
            Precalculate();
        }

        private void DamageCalculation()
        {
            
        }

    }
}