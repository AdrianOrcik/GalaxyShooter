using UnityEngine;

public class ProjectileRendererBehaviour : MonoBehaviour
{
    public AnimationScriptable AnimationController;

    private ProjectileBehaviour projectileBehaviour;
    private ProjectileRendererBase projectileRendererBase;

    private SpriteRenderer renderer;
    private Animator anim;

    private void Awake()
    {
        if (renderer == null)
        {
            renderer = GetComponentInChildren<SpriteRenderer>();
        }

        if (anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
    }

    public void Init(string tag, ProjectileBehaviour projectileBehaviour, Quaternion rotation)
    {
        transform.rotation = rotation;

        this.tag = tag;
        this.projectileBehaviour = projectileBehaviour;

        if (CompareTag(Tags.PLAYER_PROJECTILE))
        {
            projectileRendererBase = new PlayerProjectileRenderer(anim, AnimationController);
        }
        else
        {
            projectileRendererBase = new EnemyProjectileRenderer(anim, AnimationController);
        }

        projectileRendererBase.SetAnimator();
    }

    public void SetSprite(int spriteID)
    {
        renderer.sprite = projectileBehaviour.ResourceManager.GetGameSprite(spriteID);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (projectileRendererBase.CheckCollider(gameObject, other))
        {
            projectileBehaviour.Speed = 0;
            anim.SetTrigger("explosion");
        }
    }

    public void DisableObj()
    {
        projectileBehaviour.gameObject.SetActive(false);
    }
}