using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

public class ResourceManager : MainBehaviour
{
    private Dictionary<int, Sprite> GameSprites;
    public Dictionary<int, Queue<MonoBehaviour>> PoolDictionary;

    private void Awake()
    {
        MainModel.ResourceManager = this;
        AssignClass(this);
    }

    public void LoadResources()
    {
        LoadGameIcons();
        LoadPoolers();
    }

    /// <summary>
    /// Load objects into pooler depends from PoolDefinitions
    /// </summary>
    private void LoadPoolers()
    {
        PoolDictionary = new Dictionary<int, Queue<MonoBehaviour>>();

        foreach (PoolDefinition pool in GameDefinitions.PoolDefinitions)
        {
            Queue<MonoBehaviour> objPool = new Queue<MonoBehaviour>();
            for (int i = 0; i < pool.PoolAmount; i++)
            {
                MonoBehaviour projectile = LoadPoolsResources<MonoBehaviour>(pool.Path);
                projectile.gameObject.SetActive(false);
                projectile.transform.SetParent(transform);
                objPool.Enqueue(projectile);
            }

            PoolDictionary.Add(pool.ID, objPool);
        }
    }

    /// <summary>
    /// Method return monoBehaviour object by objID
    /// </summary>
    public MonoBehaviour SpawnFromPool(int ID, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(ID)) return null;

        MonoBehaviour objectToSpawn = PoolDictionary[ID].Dequeue();
        objectToSpawn.gameObject.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        PoolDictionary[ID].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    /// <summary>
    /// Method return Sprite by spriteID
    /// </summary>
    public Sprite GetGameSprite(int ID)
    {
        return !GameSprites.ContainsKey(ID) ? null : GameSprites[ID];
    }

    /// <summary>
    /// InitMethod which load icons from resources
    /// </summary>
    private void LoadGameIcons()
    {
        GameSprites = new Dictionary<int, Sprite>();
        foreach (SpriteDefinition item in GameDefinitions.SpriteDefinitions)
        {
            Sprite sprite = Resources.Load<Sprite>(item.Path);
            if (sprite != null)
            {
                GameSprites[item.ID] = sprite;
            }
        }
    }

    /// <summary>
    /// InitMethod which load game objects from resources
    /// </summary>
    public T LoadPoolsResources<T>(string path) where T : MonoBehaviour
    {
        return Instantiate(Resources.Load<T>(path),
            new Vector3(transform.position.x, transform.position.y, 0f),
            Quaternion.identity);
    }
}