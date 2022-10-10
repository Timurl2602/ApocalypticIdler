using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private int _heroDamage;
    
    public int HeroDamage
    {
        get { return _heroDamage; }
        set => _heroDamage = value;
    }

    [SerializeField] private int _attackSpeed;

    public int AttackSpeed
    {
        get { return _attackSpeed; }
        set => _attackSpeed = value;
    }
    
    

}
