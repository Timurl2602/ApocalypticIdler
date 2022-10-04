using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private int heroDamage;

    public int HeroDamage
    {
        get { return heroDamage; }
        set => heroDamage = value;
    }
    
}
