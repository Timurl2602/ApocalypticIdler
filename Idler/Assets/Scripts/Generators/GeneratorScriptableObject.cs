using UnityEngine;


namespace IdleGame
{
    [CreateAssetMenu(fileName ="Generator", menuName = "Utility/Generator", order = 0)]
    public class GeneratorScriptableObject : ScriptableObject, ISerializationCallbackReceiver
    {
        public int owned;
        public double baseCost;
        public double revenue;
        public float baseproductionTimeInSeconds;
        public float costIncrease;
        public double costForNextUpgrade;
        public double productionCyleinSeconds;
        public float upgradeAmount;
        public float productionTimeInSeconds;

        public bool CanBeBuild(GameManager gameManager)
        {
            return GameManager.instance.Money >= costForNextUpgrade;
        }

        public void Build(GameManager gameManager)
        {
            if (!CanBeBuild(gameManager))
            {
                return;
            }

            owned++;
            GameManager.instance.Money -= costForNextUpgrade;
            Precalculate();
        }

        public double Produce(float deltaTimeInSeconds)
        {
            if (owned == 0)
            {
                return 0;
            }

            productionCyleinSeconds += deltaTimeInSeconds;

            double calculatedSum = 0;

            while (productionCyleinSeconds >= productionTimeInSeconds)
            {
                calculatedSum += revenue * owned;
                productionCyleinSeconds -= productionTimeInSeconds;
            }

            return calculatedSum;

        }
        


        private void UpdateGeneratorCost()
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

        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            Precalculate();
        }
    }
}