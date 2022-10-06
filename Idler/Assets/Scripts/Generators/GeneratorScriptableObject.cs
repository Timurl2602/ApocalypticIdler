using UnityEngine;


namespace IdleGame
{
    [CreateAssetMenu(fileName ="Generator", menuName = "Utility/Generator", order = 0)]
    public class GeneratorScriptableObject : ScriptableObject
    {
        
        [Header("Upgrade Variables")]
        
        public string upgradeName;
       
        public int owned;
        
        public double baseCost;
        public double costForNextUpgrade;
        
        public float costIncrease;
        public float upgradeAmount;




        public void UpdateGeneratorCost()
        {
            //calculation for generator costs
            var calcTop = Mathf.Pow(costIncrease, owned);
            var calcBottom = Mathf.Pow(costIncrease, owned + upgradeAmount);

            costForNextUpgrade = baseCost + (calcTop - calcBottom) / (1 - costIncrease);

        }
        
        private void Precalculate()
        {
            UpdateGeneratorCost();
        }

        
        private void OnValidate()
        {
            Precalculate();

        }

    }
}