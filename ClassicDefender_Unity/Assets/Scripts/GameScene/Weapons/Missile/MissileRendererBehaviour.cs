using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileRendererBehaviour : MonoBehaviour
{
    private MissileBehaviour missileBehaviour;
    private Animator anim;
    private SpriteRenderer renderer;

    private void Awake()
    {
        if (renderer == null)
        {
            renderer = GetComponent<SpriteRenderer>();
        }

        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    public void Init(string tag, MissileBehaviour missileBehaviour)
    {
        this.tag = tag;
        this.missileBehaviour = missileBehaviour;
    }

    public void SetSprite(int spriteID)
    {
        renderer.sprite = missileBehaviour.ResourceManager.GetGameSprite(spriteID);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.ENEMY))
        {
            ActiveAnimation();
        }
    }

    public void ActiveAnimation()
    {
        missileBehaviour.Speed = 0;
        anim.SetTrigger("explosion");
    }

    public void DisableObj()
    {
        missileBehaviour.gameObject.SetActive(false);
    }
}