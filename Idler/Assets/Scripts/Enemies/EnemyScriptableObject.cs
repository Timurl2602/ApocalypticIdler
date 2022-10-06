using UnityEngine;

namespace IdleGame
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Utility/Enemy", order = 0)]
    public class EnemyScriptableObject : ScriptableObject
    {
        public int Health = 100;
        public float Speed = 3f;

    }
    
    
    
    
}




