using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MissileBehaviour : MainBehaviour
{
    public MissileRendererBehaviour MissileRendererBehaviour;
    private ShipDefinition shipDefinition;

    public int Speed;
    private float timer = 0;
    private Transform target;
    private Rigidbody2D rb;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    public void Init(string tag, ShipDefinition shipDefinition, Transform target)
    {
        //TODO: Definition
        Speed = 15;
        timer = 0;
        this.target = target;
        MissileRendererBehaviour.Init(tag, this);
        MissileRendererBehaviour.SetSprite(shipDefinition.MissileSpriteID);
    }

    private void FixedUpdate()
    {
        Move();
        UpdateRotation();
        Deactive();
    }

    private void Move()
    {
        rb.velocity = transform.right * Speed;
    }

    private void UpdateRotation()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2) target.position - rb.position;
            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            rb.angularVelocity = -rotateAmount * 500;
        }
    }

    private void Deactive()
    {
        if (target == null || !target.gameObject.activeSelf || timer >= Constants.MISSILE_TO_LIVE)
        {
            MissileRendererBehaviour.ActiveAnimation();
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}