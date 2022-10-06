using System;
using System.Collections;
using IdleGame;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    [Header("References")]
    
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] spawnPoints;
    
    [Header("Wave Manipulation")]
    
    [SerializeField] private float spawnSpeed;
    [SerializeField] private float baseSpawnCount;
    [SerializeField] private float spawnIncrease;
    
    [ReadOnly] public float enemiesKilled;
    
    [HideInInspector] public float enemiesToSpawn;
    [HideInInspector] public int spawnedEnemy;
    

    void Start()
    {
        WaveCalculation();
        StartCoroutine(SpawnEnemy(enemy));
    }

    private void Update()
    {
        if (enemiesKilled == enemiesToSpawn)
        {
            GameManager.instance.wave++;
            enemiesKilled = 0;
            spawnedEnemy = 0;
            WaveCalculation();
            StartCoroutine(SpawnEnemy(enemy));
        }
    }

    private IEnumerator SpawnEnemy(GameObject enemy)
    {
        while (spawnedEnemy < enemiesToSpawn)
        {
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
            GameObject newEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            spawnedEnemy++;
            yield return new WaitForSeconds(spawnSpeed);
        }

    }

    private void WaveCalculation()
    {
        enemiesToSpawn = (float)(baseSpawnCount*Math.Pow(spawnIncrease, GameManager.instance.wave));
    }


}
