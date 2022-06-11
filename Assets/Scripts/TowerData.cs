using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Data", menuName = "New Tower Data")]
public class TowerData : ScriptableObject
{
    public string displayName;
    public int cost;
    public float range;
    public Sprite icon;
    public GameObject spawnPrefab;
}
