using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Bson;
using UnityEngine;

public class EnemyBehaviour : ShipBase
{
    public ShipRendererBehaviour ShipRendererBehaviour;
    public ShipDefinition ShipDefinition;
    private AIManager aiManager;
    private ShipStats shipStats;

    /// <summary>
    /// Load Enemy Ship data from definition, init components and setup config data
    /// </summary>
    public void Init(EdgeCollider2D path)
    {
        ShipDefinition =
            GameDefinitions.ShipDefinitions.FirstOrDefault(x => x.ID == LevelManager.EnemyDefinitionPool.ID);

        shipStats = new ShipStats(ShipDefinition.Health, ShipDefinition.Speed, ShipDefinition.ShootTime);

        ShipRendererBehaviour = GetComponentInChildren<ShipRendererBehaviour>();
        ShipRendererBehaviour.Init(this);

        if (path != null)
        {
            aiManager = new AIManager(this);
            aiManager.Init(path, shipStats);
        }
    }

    private void Update()
    {
        if (aiManager != null)
        {
            aiManager.Movement();
            aiManager.Shooting();
        }
    }

    public void Shot()
    {
        ProjectileBehaviour projectileBehaviour =
            (ProjectileBehaviour) ResourceManager.SpawnFromPool(LevelManager.ProjectileDefinitionPool.ID,
                transform.position,
                Quaternion.identity);

        projectileBehaviour.Init(Tags.ENEMY_PROJECTILE, ShipDefinition, Vector3.left, Quaternion.Euler(0, 0, 90));
    }

    public override void Kill()
    {
        shipStats.Health -= 1;

        if (shipStats.Health == 0)
        {
            gameObject.SetActive(false);
            LevelManager.KillEnemy(this);
            return;
        }

        StartCoroutine(ShipRendererBehaviour.AnimColor(Color.red));
    }
}