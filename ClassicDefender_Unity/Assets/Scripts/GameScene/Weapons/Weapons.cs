using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class controlling availability of weapons (Shooting, bonus weapons etc...)
/// </summary>

public class Weapons
{
    private ShipBase shipBase;
    private ShipDefinition shipDefiniton;
    private ShipWeaponType shipWeaponType;

    public bool BonusShotActive;
    public float BonusShotDuration;

    private Vector3[] projectileDir = new[]
        {new Vector3(1f, 0f, 0f), new Vector3(1f, 0.10f, 0f), new Vector3(1f, -0.10f, 0f)};


    public Weapons(ShipBase shipBase, ShipDefinition shipDefiniton)
    {
        this.shipBase = shipBase;
        this.shipDefiniton = shipDefiniton;
        shipWeaponType = ShipWeaponType.OneWayShot;
    }

    public void SetWeaponType(ShipWeaponType shipWeaponType)
    {
        this.shipWeaponType = shipWeaponType;
        BonusShotDuration = Constants.BONUS_SHOT_DURATION;
        BonusShotActive = true;
    }

    public void Shot()
    {
        switch (shipWeaponType)
        {
            case ShipWeaponType.OneWayShot:
                OneWayShot();
                break;
            case ShipWeaponType.ThreeWayShot:
                ThreeWayShot();
                break;
        }
    }

    public void Update()
    {

        if (BonusShotActive)
        {
            if (BonusShotDuration < 0)
            {
                BonusShotActive = false;
                shipBase.UIPanelBehaviour.ShotBtnActiveTimer = 0;
                shipBase.UIPanelBehaviour.OnActiveShot.bg.fillAmount = 0;
                shipWeaponType = ShipWeaponType.OneWayShot;
            }

            BonusShotDuration -= Time.deltaTime;
        }
    }

    public void Missile()
    {
        int amount = shipBase.LevelManager.Enemies.Count;
        List<Transform> targets = GetTarget(amount);
        for (int i = 0; i < amount; i++)
        {
            MissileBehaviour missileBehaviour = InitMissile();
            missileBehaviour.Init(Tags.PLAYER_PROJECTILE, shipDefiniton, targets[i]);
        }

        shipBase.UIPanelBehaviour.MissileBtnActiveTimer = 0;
        shipBase.UIPanelBehaviour.OnActiveMissile.bg.fillAmount = 0;
    }

    private List<Transform> GetTarget(int amount)
    {
        List<Transform> targets = new List<Transform>();

        for (int i = 0; i < amount; i++)
        {
            targets.Add(shipBase.LevelManager.Enemies[i].transform);
        }

        return targets;
    }

    private void OneWayShot()
    {
        ProjectileBehaviour projectileBehaviour = InitProjectile();
        projectileBehaviour.Init(Tags.PLAYER_PROJECTILE, shipDefiniton, Vector3.right,
            Quaternion.Euler(0, 0, -90));
    }


    private void ThreeWayShot()
    {
        for (int i = 0; i < projectileDir.Length; i++)
        {
            ProjectileBehaviour projectileBehaviour = InitProjectile();
            projectileBehaviour.Init(Tags.PLAYER_PROJECTILE, shipDefiniton, projectileDir[i],
                Quaternion.Euler(0, 0, -90));
        }
    }

    private ProjectileBehaviour InitProjectile()
    {
        return (ProjectileBehaviour) shipBase.ResourceManager.SpawnFromPool(
            shipBase.LevelManager.ProjectileDefinitionPool.ID,
            shipBase.transform.position,
            Quaternion.identity);
    }

    private MissileBehaviour InitMissile()
    {
        return (MissileBehaviour) shipBase.ResourceManager.SpawnFromPool(
            shipBase.LevelManager.MissileDefinitionPool.ID,
            shipBase.transform.position,
            Quaternion.identity);
    }
}