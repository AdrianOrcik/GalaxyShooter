using System;
using System.Collections.Generic;
using System.Linq;

public class LevelStats
{
    private LevelManager levelBehaviour;

    public LevelDefinition LevelDefinition;
    public List<LevelDefinition> WavesDefiniton;

    public float TimeToSpawn = 0.5f;
    public int KilledEnemy;
    public int AliveEnemy;
    public int ActualWave = 0;
    public List<int> TotalWaveEnemy;
    public List<int> EnemyPaths;
    public int PathID = 0;

    public LevelStats(LevelManager levelBehaviour)
    {
        this.levelBehaviour = levelBehaviour;
    }

    public void Init()
    {
        int Level = levelBehaviour.GameManager.GameDataLoader.GameData.PlayerData.GetLevel();
        LevelDefinition = levelBehaviour.GameDefinitions.LevelDefinitions.FirstOrDefault(x => x.Level == Level);

        WavesDefiniton = new List<LevelDefinition>();
        TotalWaveEnemy = new List<int>();

        foreach (LevelDefinition levelDef in levelBehaviour.GameDefinitions.LevelDefinitions)
        {
            if (levelDef.Level == Level)
            {
                WavesDefiniton.Add(levelDef);
                TotalWaveEnemy.Add(levelDef.ActualEnemy);
            }
        }

        WavesList2Arr();
    }

    private void WavesList2Arr()
    {
        EnemyPaths = new List<int>();
        string wavesList = LevelDefinition.WavesList;
        EnemyPaths = wavesList.Split(',').Select(Int32.Parse).ToList();
    }
}