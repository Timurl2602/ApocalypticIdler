using UnityEngine;

namespace IdleGame
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Utility/Enemy", order = 0)]
    public class EnemyScriptableObject : ScriptableObject
    {
        public int health = 100;
        public float healthIncrease = 1.7f;
        public float speed = 3f;
        
    }
    
    
    
    
}




