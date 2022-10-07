using System;
using UnityEngine;
using TMPro;

namespace IdleGame
{
    public class ShowMoney : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyText;

        private void Update()
        {
            moneyText.text = string.Format((GameManager.instance.Money < 1000) ? "{0:F2}" : "{0:0.00e0}", GameManager.instance.Money);
        }
    }
}
