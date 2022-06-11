using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "New Wave Data")]
public class WaveData : ScriptableObject
{
    public EnemySet[] enemySets;
    
    [System.Serializable]
    public class EnemySet
    {
        public GameObject enemyPrefab;
        public int spawnCount;
        public float spawnDelay;
        public float spawnRate;
    }
}
