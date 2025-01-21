using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //parameters
    int wayPointIndex = 0;
    [SerializeField] float enemyMoveSpeed = 2f;

    //cached references
    [SerializeField] List<Transform> waypoints;
    void Start()
    {
        
    }


    void Update()
    {
        moveEnemyOnPath();
    }

    //This makes it so the enemy loops on the created path from the waypoints
    private void moveEnemyOnPath()
    {
        if(wayPointIndex <= waypoints.Count-1)
        {
            //Moves towards the next waypoint and when it hits it it adds one to the counter which directs it to the next waypoint
            var targetWayPointPosition = waypoints[wayPointIndex].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetWayPointPosition, enemyMoveSpeed * Time.deltaTime);

            if(transform.position == targetWayPointPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            //Resets the waypoint index back to 0 once it reaches the end of the waypoints
            //This makes the cycle repeat 
            wayPointIndex = 0;
        }
    }
}
