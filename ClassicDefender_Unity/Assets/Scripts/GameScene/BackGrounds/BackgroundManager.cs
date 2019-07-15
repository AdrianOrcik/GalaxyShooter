using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BackgroundManager : MainBehaviour
{
    public float Speed = Constants.BACKGROUND_SPEED_FORWARD;
    private List<BackgroundLayerBehaviour> backgroundLayerBehaviour = new List<BackgroundLayerBehaviour>();

    public PoolDefinition BackgrounndPool;

    public void Start()
    {
        BackgrounndPool = GameDefinitions.PoolDefinitions.FirstOrDefault(x => x.PoolType == PoolType.Background);
        InitBackgroundLayer(transform.position);
    }

    public void Update()
    {
        BackgroundWraps();
    }

    private void BackgroundWraps()
    {
        bool screenPosX = false;
        foreach (BackgroundLayerBehaviour layer in backgroundLayerBehaviour)
        {
            screenPosX = layer.transform.position.x < -10;
            if (screenPosX)
            {
                backgroundLayerBehaviour.Remove(layer);
                break;
            }
        }

        if (screenPosX)
        {
            Vector3 position = new Vector3(30, 0, 0);
            InitBackgroundLayer(position);
        }
    }

    private void InitBackgroundLayer(Vector3 position)
    {
        BackgroundLayerBehaviour backgroundLayer =
            (BackgroundLayerBehaviour) ResourceManager.SpawnFromPool(BackgrounndPool.ID, position,
                Quaternion.identity);
        backgroundLayer.Init(this);
        backgroundLayerBehaviour.Add(backgroundLayer);
    }
}