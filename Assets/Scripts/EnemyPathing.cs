using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //params
    int wayPointIndex = 0;
    [SerializeField] float enemyMoveSpeed = 2f;

    //cached refs
    [SerializeField] List<Transform> waypoints;
    void Start()
    {
        
    }


    void Update()
    {
        moveEnemyOnPath();
    }

    private void moveEnemyOnPath()
    {
        if(wayPointIndex <= waypoints.Count-1)
        {
            var targetWayPointPosition = waypoints[wayPointIndex].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetWayPointPosition, enemyMoveSpeed * Time.deltaTime);

            if(transform.position == targetWayPointPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            wayPointIndex = 0;
        }
    }
}
