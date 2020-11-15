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
    
    public void Walk(bool move)
    {
        animator.SetBool(AnimationTags.MOVEMENT, move);
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
}
