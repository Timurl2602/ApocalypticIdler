using System;
using UnityEngine;
using TMPro;

namespace IdleGame
{
    public class EnemyCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _enemyCounter;

        private void Update()
        {
            _enemyCounter.text = WaveManager.Instance.EnemiesKilled + "/" + Mathf.Round(WaveManager.Instance.EnemiesToSpawn) ;
        }
    }
}