using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewTower : MonoBehaviour
{
    public Transform rangeObject;

    public void SetTower(TowerData tower)
    {
        rangeObject.localScale = new Vector3(tower.range * 2, 0.1f, tower.range * 2);
    }
}
