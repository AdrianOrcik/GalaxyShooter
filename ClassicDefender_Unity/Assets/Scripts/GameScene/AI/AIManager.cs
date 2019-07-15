using System;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Random = UnityEngine.Random;

/// <summary>
/// Class simulate enemy waypoint base system and shooting 
/// </summary>
public class AIManager
{
    private EnemyBehaviour enemyBehaviour;
    private Waypoints waypoints;
    private ShipStats shipStats;

    private float timer = 0f;

    public AIManager(EnemyBehaviour enemyBehaviour)
    {
        this.enemyBehaviour = enemyBehaviour;
    }

    public void Init(EdgeCollider2D edgePath, ShipStats shipStats)
    {
        this.shipStats = shipStats;
        waypoints = new Waypoints();
        waypoints.Init(enemyBehaviour, edgePath);
    }

    public void Movement()
    {
        if (enemyBehaviour.transform.position == waypoints.Points[waypoints.CurrentPoint])
        {
            waypoints.NextPoint();
        }
        else
        {
            enemyBehaviour.transform.position = Vector3.MoveTowards(enemyBehaviour.transform.position,
                waypoints.Points[waypoints.CurrentPoint],
                Time.deltaTime * shipStats.Speed);
        }
    }

    public void Shooting()
    {
        if (timer >= shipStats.ShootTime)
        {
            int random = Random.Range(0, 10);
            if (random > 6)
            {
                enemyBehaviour.Shot();
            }

            timer = 0;
        }

        timer += Time.deltaTime;
    }

    protected void UpdateRotation()
    {
//        float angle = Mathf.Atan2(points[pointID].y, points[pointID].x) * Mathf.Rad2Deg;
//
//        if (Mathf.FloorToInt(Mathf.Abs(angle)) != 90 && Mathf.FloorToInt(angle) != 0)
//        {
//            enemyBehaviour.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
//        }
    }
}