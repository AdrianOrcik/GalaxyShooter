using System.Collections;
using System.Collections.Generic;
using GameScene;
using UnityEngine;


public class GameData
{
    public PlayerData PlayerData;

    public void InitData(GameDataLoader gameDataLoader)
    {    
        PlayerData = new PlayerData();
        PlayerData.InitData(gameDataLoader);
    }
    
    
}