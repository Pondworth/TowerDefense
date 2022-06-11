using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy target;
    private int damage;
    private float moveSpeed; 

    public GameObject hitSpawnPrefab;

    public void Initialize (Enemy target, int damage, float moveSpeed)
    {
        this.target = target;
        this.damage = damage;
        this.moveSpeed = moveSpeed;
    }

    void Update()
    {
        if (target != null)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            
            transform.LookAt(target.transform);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
            {
                target.TakeDamage(damage);

                if (hitSpawnPrefab != null)
                    Instantiate(hitSpawnPrefab, transform.position, Quaternion.identity);
                
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
