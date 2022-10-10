using System;
using System.Collections;
using IdleGame;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    [Header("References")]
    
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _hero;
    [SerializeField] private GameObject[] _spawnPoints;
    
    [Header("Wave Manipulation")]
    
    [SerializeField] private float _spawnSpeed;
    [SerializeField] private float _baseSpawnCount;
    [SerializeField] private float _spawnIncrease;
    
    [ReadOnly] public float enemiesKilled;
    
    [HideInInspector] public float EnemiesToSpawn;
    [HideInInspector] public int SpawnedEnemy;
    

    void Start()
    {
        WaveCalculation();
        StartCoroutine(SpawnEnemy(_enemy));
    }

    private void Update()
    {
        if (enemiesKilled == EnemiesToSpawn)
        {
            GameManager.Instance.Wave++;
            enemiesKilled = 0;
            SpawnedEnemy = 0;
            WaveCalculation();
            StartCoroutine(SpawnEnemy(_enemy));
        }
    }

    private IEnumerator SpawnEnemy(GameObject enemy)
    {
        while (SpawnedEnemy < EnemiesToSpawn)
        {
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform;
            GameObject newEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            //var enemyComponent = newEnemy.GetComponent<Enemy>();
            //enemyComponent.Init(hero, this);
            SpawnedEnemy++;
            yield return new WaitForSeconds(_spawnSpeed);
        }

    }

    private void WaveCalculation()
    {
        EnemiesToSpawn = (float)(_baseSpawnCount*Math.Pow(_spawnIncrease, GameManager.Instance.Wave));
    }


}
