using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileBehaviour : MainBehaviour
{
    public ProjectileRendererBehaviour ProjectileRendererBehaviour;
    private ShipDefinition shipDefinition;

    public int Speed = 0;
    private float timer = 0;
    private Vector3 direction = Vector3.zero;

    public void Init(string tag, ShipDefinition shipDefinition, Vector3 direction, Quaternion rotation)
    {
        Speed = shipDefinition.ProjectileSpeed;
        ProjectileRendererBehaviour.Init(tag, this, rotation);
        ProjectileRendererBehaviour.SetSprite(shipDefinition.ProjectileSpriteID);

        this.direction = direction;
    }

    private void Update()
    {
        Move();
        Deactive();
    }

    private void Move()
    {
        transform.position += direction * Time.deltaTime * Speed;
    }

    private void Deactive()
    {
        if (timer >= Constants.PROJECTILE_TO_LIVE)
        {
            gameObject.SetActive(false);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}