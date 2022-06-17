using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float range;
    public int damage;
    public LayerMask enemyLayerMask;

    private void Start()
    {
        transform.localScale = Vector3.one * range;
        DamageEnemies();
        StartCoroutine(ExplodeAnimation());
    }

    void DamageEnemies()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, range, enemyLayerMask);

        for (int x = 0; x < enemies.Length; x++)
        {
            enemies[x].GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    IEnumerator ExplodeAnimation()
    {
        yield return new WaitForSeconds(0.2f);

        while (transform.localScale.x != 0.0f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, Time.deltaTime * 3);
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
