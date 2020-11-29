using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterHealth : MonoBehaviour
{
    private new CharacterAnimation animation;
    private EnemyManager enemy;

    public float health = 100.0f;
    private bool dead = false;
    public bool isPlayer;

    void Awake()
    {
        animation = GetComponentInChildren<CharacterAnimation>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (dead) return;

        health -= damage;

        if (health <= 0.0f)
        {
            animation.Death();
            dead = true;

            /* if (isPlayer)
            {

            } */

            return;
        }

        if (!isPlayer)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) < 1)
                {
                    animation.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 3) < 2)
                {
                    animation.Hit();
                }
            }
        }
    }
}
