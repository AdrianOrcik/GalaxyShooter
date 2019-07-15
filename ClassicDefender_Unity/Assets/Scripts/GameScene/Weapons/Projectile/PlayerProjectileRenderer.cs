using UnityEngine;

public class PlayerProjectileRenderer : ProjectileRendererBase
{
    public PlayerProjectileRenderer(Animator anim, AnimationScriptable animationController)
    {
        this.animationController = animationController;
        this.anim = anim;
    }

    public override void SetAnimator()
    {
//        anim.runtimeAnimatorController =
//            animationController.AnimatorControllers[(int) AnimatorControllers.PlayerProjectile];
    }

    public override bool CheckCollider(GameObject obj, Collider2D other)
    {
        return obj.CompareTag(Tags.PLAYER_PROJECTILE) && other.CompareTag(Tags.ENEMY);
    }
}