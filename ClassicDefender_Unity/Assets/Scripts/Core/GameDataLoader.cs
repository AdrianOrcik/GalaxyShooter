using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataLoader : MainBehaviour
{
    public GameData GameData;

    public void SaveData()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SaveGameData();
        }
    }

    public void LoadGameData()
    {

//        if (IsPathValid("GameData"))
//        {
//            GameData = LoadJson<GameData>("GameData");
//        }
//        else
        {
            GameData = new GameData();
            GameData.InitData(this);
        }
    }

    void SaveGameData()
    {
        //SaveJson("GameData", GameData);
    }

    void SaveJson(string fileName, object saveData)
    {
        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });
        File.WriteAllText(Application.persistentDataPath + "/" + fileName + ".json", json);
    }

    T LoadJson<T>(string fileName)
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/" + fileName + ".json");
        return JsonConvert.DeserializeObject<T>(json);
    }

    bool IsPathValid(string fileName)
    {
        return File.Exists(Application.persistentDataPath + "/" + fileName + ".json");
    }
}