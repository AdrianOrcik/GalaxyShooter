using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public enum AIWaypointFly
{
    Forward = 0,
    Reverse = 1,
    Random = 2
}

public class Waypoints
{
    public List<Vector3> Points => points;
    public int CurrentPoint => currentPoint;

    private List<Vector3> points;
    private int currentPoint = 0;
    private EnemyBehaviour enemyBehaviour;
    private EdgeCollider2D edgePath;

    private AIWaypointFly aiWaypointFly;

    public Waypoints()
    {
    }

    public void Init(EnemyBehaviour enemyBehaviour, EdgeCollider2D edgePath)
    {
        this.enemyBehaviour = enemyBehaviour;
        this.edgePath = edgePath;

        points = Vector2Waypoints();

        aiWaypointFly = (AIWaypointFly) Random.Range(0, 3);
        InitPoint();
    }

    private void InitPoint()
    {
        switch (aiWaypointFly)
        {
            case AIWaypointFly.Forward:
                currentPoint = 0;
                break;
            case AIWaypointFly.Reverse:
                currentPoint = points.Count - 1;
                break;
            case AIWaypointFly.Random:
                RandomPointsFly();
                break;
        }
    }

    //TODO: Reverse Fly, Fly, RandomFly
    public void NextPoint()
    {
        switch (aiWaypointFly)
        {
            case AIWaypointFly.Forward:
                ForwardFly();
                break;
            case AIWaypointFly.Reverse:
                ReverseFly();
                break;
            case AIWaypointFly.Random:
                RandomPointsFly();
                break;
        }
    }

    public void ForwardFly()
    {
        if (currentPoint == points.Count - 1)
        {
            currentPoint = 0;
        }
        else
        {
            currentPoint++;
        }
    }

    public void ReverseFly()
    {
        if (currentPoint == 0)
        {
            currentPoint = points.Count - 1;
        }
        else
        {
            currentPoint--;
        }
    }

    public void RandomPointsFly()
    {
        currentPoint = Random.Range(0, points.Count - 1);
    }

    private List<Vector3> Vector2Waypoints()
    {
        List<Vector3> waypoints = new List<Vector3>();
        foreach (Vector3 point in edgePath.points)
        {
            Vector3 tmpPoint = new Vector3(
                enemyBehaviour.transform.position.x + point.x + edgePath.transform.position.x +
                (enemyBehaviour.LevelManager.EnemySpawnPoint.position.x / 2) * -1,
                enemyBehaviour.transform.position.y + point.y);

            waypoints.Add(tmpPoint);
        }

        return waypoints;
    }
}