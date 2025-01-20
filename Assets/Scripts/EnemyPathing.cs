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

    //This makes it so the enemy loops on the created path from the waypoints
    //Modified code from the schmup lectures so that it resets the waypoint index back to 0 once it reaches the end of the waypoints
    //This makes the cycle repeat 
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
