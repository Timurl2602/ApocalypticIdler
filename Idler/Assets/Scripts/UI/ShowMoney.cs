using System;
using UnityEngine;
using TMPro;

namespace IdleGame
{
    public class ShowMoney : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;

        private void Update()
        {
            _moneyText.text = string.Format((GameManager.Instance.Money < 1000) ? "{0:F2}" : "{0:0.00e0}", GameManager.Instance.Money);
        }
    }
}
