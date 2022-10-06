using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private int heroDamage;
    
    public int HeroDamage
    {
        get { return heroDamage; }
        set => heroDamage = value;
    }

    [SerializeField] private int attackSpeed;

    public int AttackSpeed
    {
        get { return attackSpeed; }
        set => attackSpeed = value;
    }

}
