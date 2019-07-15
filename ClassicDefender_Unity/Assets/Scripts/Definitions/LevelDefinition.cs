using System;
using System.Collections.Generic;

[System.Serializable]
public class LevelDefinition
{
    public int Level;
    public int TotalWaves;
    public int TotalEnemy;
    public int ActualWave;
    public int ActualEnemy;
    public string WavesList;
    public int BackgroundID;

    public LevelDefinition()
    {
    }
}