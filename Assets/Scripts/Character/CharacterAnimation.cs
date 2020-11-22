using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Idle()
    {
        animator.Play(AnimationTags.IDLE);
    }

    public void Walk(bool move)
    {
        animator.SetBool(AnimationTags.MOVEMENT, move);
    }

    public void EnemyAttack(int attack)
    {
             if (attack == 0) animator.SetTrigger(AnimationTags.ATTACK1);
        else if (attack == 1) animator.SetTrigger(AnimationTags.ATTACK2);
        else if (attack == 2) animator.SetTrigger(AnimationTags.ATTACK3);
    }

    public void Punch1()
    {
        animator.SetTrigger(AnimationTags.PUNCH1);
    }

    public void Punch2()
    {
        animator.SetTrigger(AnimationTags.PUNCH2);
    }

    public void Punch3()
    {
        animator.SetTrigger(AnimationTags.PUNCH3);
    }

    public void Kick1()
    {
        animator.SetTrigger(AnimationTags.KICK1);
    }

    public void Kick2()
    {
        animator.SetTrigger(AnimationTags.KICK2);
    }

    public void Hit()
    {
        animator.SetTrigger(AnimationTags.HIT);
    }

    public void KnockDown()
    {
        animator.SetTrigger(AnimationTags.KNOCK_DOWN);
    }

    public void StandUp()
    {
        animator.SetTrigger(AnimationTags.STAND_UP);
    }

    public void Death()
    {
        animator.SetTrigger(AnimationTags.DEATH);
    }
}
