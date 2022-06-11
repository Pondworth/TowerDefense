using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public Transform[] waypoints;

    void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        for (int x = 0; x < waypoints.Length; x++)
        {
            Gizmos.DrawWireSphere(waypoints[x].position, 0.25f);
            
            if(x < waypoints.Length - 1)
                Gizmos.DrawLine(waypoints[x].position, waypoints[x+1].position);
        }
    }
}
