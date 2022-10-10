using System;
using UnityEngine;
using TMPro;

namespace IdleGame
{
    public class ShowWave : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _waveText;

        private void Update()
        {
            _waveText.text = ("Wave: ") + GameManager.Instance.Wave ;
        }
    }
}