using System;
using IdleGame;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
        var moneyToAdd = 50 * Mathf.Pow((float)1.25, GameManager.Instance.Wave);
        GameManager.Instance.AddMoney(moneyToAdd);
        Debug.Log(moneyToAdd);
    }
}
