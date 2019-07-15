using UnityEngine;


public class EnemyProjectileRenderer : ProjectileRendererBase
{
    public EnemyProjectileRenderer(Animator anim, AnimationScriptable animationController)
    {
        this.animationController = animationController;
        this.anim = anim;
    }

    public override void SetAnimator()
    {
//        anim.runtimeAnimatorController =
//            animationController.AnimatorControllers[(int) AnimatorControllers.EnemyProjectile];
    }

    public override bool CheckCollider(GameObject obj, Collider2D other)
    {
        return obj.CompareTag(Tags.ENEMY_PROJECTILE) && other.CompareTag(Tags.PLAYER);
    }
}