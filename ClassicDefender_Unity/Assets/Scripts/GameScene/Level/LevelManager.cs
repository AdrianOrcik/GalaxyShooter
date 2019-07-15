using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MainBehaviour
{
    public EnemyPathBehaviour EnemyPaths;
    public List<EnemyBehaviour> Enemies;

    public Transform PlayerSpawnPoint;
    public Transform EnemySpawnPoint;
    [Header("Runtime Instance")] public PlayerBehaviour PlayerBehaviour;

    private float actualTime = 0f;

    public LevelStats LevelStats;
    public PoolDefinition PlayerDefitionPool;
    public PoolDefinition EnemyDefinitionPool;
    public PoolDefinition ProjectileDefinitionPool;
    public PoolDefinition MissileDefinitionPool;

    public bool gameOver = false;


    private void Start()
    {
        LevelStats = new LevelStats(this);
        LevelStats.Init();

        Init();
    }

    private void Init()
    {
        PlayerDefitionPool = GameDefinitions.PoolDefinitions.FirstOrDefault(x => x.PoolType == PoolType.Player);
        EnemyDefinitionPool = GameDefinitions.PoolDefinitions.FirstOrDefault(x => x.PoolType == PoolType.Enemy);
        ProjectileDefinitionPool =
            GameDefinitions.PoolDefinitions.FirstOrDefault(x => x.PoolType == PoolType.Projectile);
        MissileDefinitionPool = GameDefinitions.PoolDefinitions.FirstOrDefault(x => x.PoolType == PoolType.Missile);

        if (PlayerDefitionPool != null)
        {
            PlayerBehaviour = (PlayerBehaviour) ResourceManager.SpawnFromPool(PlayerDefitionPool.ID,
                PlayerSpawnPoint.transform.position,
                Quaternion.identity);
            PlayerBehaviour.Init();
        }
    }

    private void SpawnEnemies()
    {
        if (Enemies.Count == 0)
        {
            Enemies = new List<EnemyBehaviour>();
        }

        EnemyBehaviour enemy = (EnemyBehaviour) ResourceManager.SpawnFromPool(EnemyDefinitionPool.ID,
            EnemySpawnPoint.transform.position,
            Quaternion.identity);

        enemy.Init(EnemyPaths.GetPath(LevelStats.EnemyPaths[LevelStats.PathID]));
        Enemies.Add(enemy);
    }

    public void KillEnemy(EnemyBehaviour enemy)
    {
        if (Enemies.Contains(enemy))
        {
            Enemies.Remove(enemy);
        }

        LevelStats.KilledEnemy++;
        UIPanelBehaviour.SetWaveProgress(LevelStats.KilledEnemy, LevelStats.LevelDefinition.TotalEnemy);
        InitEnemyWave();
    }

    private void InitEnemyWave()
    {
        if (Enemies.Count == 0)
        {
            LevelStats.AliveEnemy = 0;
            LevelStats.PathID++;
            LevelStats.ActualWave++;

            if (LevelStats.ActualWave >= LevelStats.LevelDefinition.TotalWaves)
            {
                ScreenManager.ActiveWinScreen();
                OnEndLevel();
            }
        }
    }

    private void Update()
    {
        if (gameOver) return;

        PlayerLevelWraps();

        if (actualTime >= LevelStats.TimeToSpawn &&
            LevelStats.AliveEnemy < LevelStats.TotalWaveEnemy[LevelStats.ActualWave])
        {
            LevelStats.AliveEnemy++;
            actualTime = 0f;
            SpawnEnemies();
        }

        actualTime += Time.deltaTime;
    }

    public void OnEndLevel()
    {
        gameOver = true;
        PlayerBehaviour.gameObject.SetActive(false);
        foreach (EnemyBehaviour enemy in Enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    private void PlayerLevelWraps()
    {
        Vector3 screenPoint = CameraManager.Camera.WorldToViewportPoint(PlayerBehaviour.transform.position);
        bool screenPosY = screenPoint.y < Constants.MIN_POSITION || screenPoint.y > Constants.MAX_POSITION;
        bool screenPosX = screenPoint.x < Constants.MIN_POSITION || screenPoint.x > Constants.MAX_POSITION;

        if (screenPosY || screenPosX)
        {
            Vector3 worldPoint = CameraManager.Camera.ViewportToWorldPoint(screenPoint);
            if (screenPosX)
            {
                worldPoint.x *= -1;
            }
            else
            {
                worldPoint.y *= -1;
            }

            PlayerBehaviour =
                (PlayerBehaviour) ResourceManager.SpawnFromPool(PlayerDefitionPool.ID, worldPoint,
                    Quaternion.identity);
        }
    }
}