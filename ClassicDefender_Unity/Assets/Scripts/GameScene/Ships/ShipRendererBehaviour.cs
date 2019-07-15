using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRendererBehaviour : MonoBehaviour
{
    private SpriteRenderer renderer;
    private ShipBase shipBase;

    private void Awake()
    {
        if (renderer == null)
        {
            renderer = GetComponent<SpriteRenderer>();
        }
    
        //Polygon collider add runtime in awake cause adjust on sprite
        gameObject.AddComponent<PolygonCollider2D>().isTrigger = true;
    }

    public void Init(ShipBase shipBase)
    {
        this.shipBase = shipBase;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag(Tags.PLAYER) && other.CompareTag(Tags.ENEMY_PROJECTILE))
        {
            Debug.Log("KILL1: " + other.gameObject.name);
            shipBase.Kill();
        }

        if (CompareTag(Tags.ENEMY) && other.CompareTag(Tags.PLAYER_PROJECTILE))
        {
            Debug.Log("KILL2");
            shipBase.Kill();
        }
    }

    public IEnumerator AnimColor(Color animColor)
    {
        float r = animColor.r;
        float g = animColor.g;
        float b = animColor.b;
        renderer.color = animColor;

        while (renderer.color != Color.white)
        {
            if (r < 1) r += 0.1f;
            if (g < 1) g += 0.1f;
            if (b < 1) b += 0.1f;
            animColor = new Color(r, g, b, 1);
            renderer.color = animColor;
            yield return null;
        }
    }
}