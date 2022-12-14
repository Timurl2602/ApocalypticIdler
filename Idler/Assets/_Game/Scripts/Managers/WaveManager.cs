using System;
using System.Collections;
using IdleGame;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    
    public static WaveManager Instance;
    
    [Header("References")]
    
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _spawnPoints;
    
    [Header("Wave Manipulation")]
    
    [SerializeField] private float _spawnSpeed;
    [SerializeField] private float _baseSpawnCount;
    [SerializeField] private float _spawnIncrease;
    
    [ReadOnly] public float EnemiesKilled;
    [ReadOnly] public float EnemiesToSpawn;
    [ReadOnly] public int SpawnedEnemy;
    

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        EnemiesToSpawn = PlayerPrefs.GetFloat("enemyCount");
    }
    void Start()
    {
        if (GameManager.Instance.Wave == 1)
        {
            EnemiesToSpawn = _baseSpawnCount;
        }  
        
        StartCoroutine(SpawnEnemy(_enemy));
    }

    private void Update()
    {
        if (EnemiesKilled >= EnemiesToSpawn)
        {
            GameManager.Instance.Wave++;
            EnemiesKilled = 0;
            SpawnedEnemy = 0;
            WaveCalculation();
            StartCoroutine(SpawnEnemy(_enemy));
            PlayerPrefs.SetInt("wave", GameManager.Instance.Wave);
        }
    }

    private IEnumerator SpawnEnemy(GameObject enemy)
    {
        while (SpawnedEnemy < EnemiesToSpawn)
        {
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform;
            GameObject newEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            SpawnedEnemy++;
            yield return new WaitForSeconds(_spawnSpeed);
        }

    }

    private void WaveCalculation()
    {
        EnemiesToSpawn = (float)(_baseSpawnCount*Math.Pow(_spawnIncrease, GameManager.Instance.Wave));
        PlayerPrefs.SetFloat("enemyCount", EnemiesToSpawn);
    }


}
