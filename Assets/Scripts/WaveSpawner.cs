using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public WaveData[] waves;
    public int curWave = 0;

    public int remainingEnemies;

    [Header("Components")] 
    public Transform enemySpawnPos;
    public TextMeshProUGUI waveText;
    public GameObject nextWaveButton;

    void OnEnable ()
    {
        Enemy.OnDestroyed += OnEnemyDestroyed;
    }
    void OnDisable ()
    {
        Enemy.OnDestroyed -= OnEnemyDestroyed;
    }
    
    public void SpawnNextWave ()
    {
        curWave++;

        if (curWave - 1 == waves.Length)
            return;

        waveText.text = $"Wave: {curWave}";

        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave ()
    {
        nextWaveButton.SetActive(false);
        WaveData wave = waves[curWave - 1];

        for (int x = 0; x < wave.enemySets.Length; x++)
        {
            yield return new WaitForSeconds(wave.enemySets[x].spawnDelay);
            
            for (int y = 0; y < wave.enemySets[x].spawnCount; y++)
            {
                SpawnEnemy(wave.enemySets[x].enemyPrefab);
                yield return new WaitForSeconds(wave.enemySets[x].spawnRate);
            }
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab, enemySpawnPos.position, Quaternion.identity);
        remainingEnemies++;
    }

    public void OnEnemyDestroyed()
    {
        remainingEnemies--;
        
        if (remainingEnemies == 0)
            nextWaveButton.SetActive(true);
    }
}