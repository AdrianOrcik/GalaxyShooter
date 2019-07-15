using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLayerBehaviour : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    private BackgroundManager backgroundManager;
    private Vector3 moveVector;

    public void Init(BackgroundManager backgroundManager)
    {
        this.backgroundManager = backgroundManager;
        int ID = backgroundManager.LevelManager.LevelStats.LevelDefinition.BackgroundID;
        SpriteRenderer.sprite = backgroundManager.ResourceManager.GetGameSprite(ID);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        bool interpolate = backgroundManager.LevelManager.PlayerBehaviour.PlayerMove.normalized.x <= 0;
        if (interpolate)
        {
            moveVector = Vector3.left * backgroundManager.Speed;
        }
        else
        {
            moveVector = Vector3.left * (backgroundManager.Speed - Constants.BACKGROUND_SPEED_BACK);
        }

        transform.position += moveVector *
                              Time.deltaTime + backgroundManager.LevelManager.PlayerBehaviour.PlayerMove.normalized /
                              Constants.BACKGROUND_DIVISOR;
    }
}