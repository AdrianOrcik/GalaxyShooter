using UnityEngine;

/// <summary>
/// Class managing Rendering of shooting projectils by Player and Enemies
/// Method are overrided by own animations and trigger behaviours
/// </summary>
public abstract class ProjectileRendererBase
{
    protected Animator anim;
    protected AnimationScriptable animationController;

    public virtual void SetAnimator()
    {
    }

    public virtual bool CheckCollider(GameObject obj, Collider2D other)
    {
        return false;
    }
}