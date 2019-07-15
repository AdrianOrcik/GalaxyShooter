using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

/// <summary>
/// Class simulate client server architecture where json data looks like game data from server.
/// Data are stored in definition arrays bellow.
/// </summary>
[Serializable]
public class GameDefinitions : MainBehaviour
{
    public SpriteDefinition[] SpriteDefinitions;
    public ShipDefinition[] ShipDefinitions;
    public PoolDefinition[] PoolDefinitions;
    public LevelDefinition[] LevelDefinitions;

    void Awake()
    {
        MainModel.GameDefinitions = this;
    }

    public void LoadDefinitions()
    {
        SpriteDefinitions = LoadJson<SpriteDefinition[]>("SpriteDefinition");
        ShipDefinitions = LoadJson<ShipDefinition[]>("ShipDefinition");
        PoolDefinitions = LoadJson<PoolDefinition[]>("PoolDefinition");
        LevelDefinitions = LoadJson<LevelDefinition[]>("LevelDefinition");

        GameManager.EventManager.OnDefinitionsDownloaded();
    }

    T LoadJson<T>(string fileName)
    {
        TextAsset json = Resources.Load<TextAsset>("Definitions/" + fileName);
        return JsonConvert.DeserializeObject<T>(json.text);
    }
}