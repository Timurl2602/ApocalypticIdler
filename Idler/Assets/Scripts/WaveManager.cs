using System;
using System.Collections;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    public Enemy enemyScript;
    
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnSpeed;
    
    [SerializeField]
    private GameObject[] spawnPoints;

    private int wave;

    private int enemyCount;
    
    


    void Start()
    {
        StartCoroutine(SpawnEnemy(enemy));
    }

    private void Update()
    {
        // !!!!!!
        UpdateHealth();
    }
    
    private IEnumerator SpawnEnemy(GameObject enemy)
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
        GameObject newEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnSpeed);

    }

    public void UpdateHealth()
    {
  
        var x = 100 * Math.Pow(1.7, 3 - 1);
        Debug.Log(x);
    }
    
    
}
