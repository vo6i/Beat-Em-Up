using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Idle()
    {
        animator.Play(AnimationTag.IDLE);
    }

    public void Walk(bool move)
    {
        animator.SetBool(AnimationTag.MOVEMENT, move);
    }

    public void EnemyAttack(int attack)
    {
             if (attack == 0) animator.SetTrigger(AnimationTag.ATTACK1);
        else if (attack == 1) animator.SetTrigger(AnimationTag.ATTACK2);
        else if (attack == 2) animator.SetTrigger(AnimationTag.ATTACK3);
    }

    public void Punch1()
    {
        animator.SetTrigger(AnimationTag.PUNCH1);
    }

    public void Punch2()
    {
        animator.SetTrigger(AnimationTag.PUNCH2);
    }

    public void Punch3()
    {
        animator.SetTrigger(AnimationTag.PUNCH3);
    }

    public void Kick1()
    {
        animator.SetTrigger(AnimationTag.KICK1);
    }

    public void Kick2()
    {
        animator.SetTrigger(AnimationTag.KICK2);
    }

    public void Hit(int type)
    {
        string hitType = type == 0 ? "" : type.ToString();
        animator.SetTrigger(AnimationTag.HIT + hitType);
    }

    public void KnockDown()
    {
        animator.SetTrigger(AnimationTag.KNOCK_DOWN);
    }

    public void StandUp()
    {
        animator.SetTrigger(AnimationTag.STAND_UP);
    }

    public void Death()
    {
        animator.SetTrigger(AnimationTag.DEATH);
    }
}
