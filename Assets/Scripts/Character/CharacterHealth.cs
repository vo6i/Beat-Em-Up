using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterHealth : MonoBehaviour
{
    private new CharacterAnimation animation;
    private SlowMotion slowMotion;
    private HealthBar healthBar;

    public float health = 100.0f;
    private bool dead = false;
    public bool isPlayer;

    void Awake()
    {
        slowMotion = GetComponent<SlowMotion>();
        animation = GetComponentInChildren<CharacterAnimation>();

        if (isPlayer)
        {
            healthBar = GetComponent<HealthBar>();
        }
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (dead) return;
        health = Mathf.Max(health - damage, 0.0f);

        if (isPlayer)
        {
            healthBar.UpdateHealth(health);
        }

        if (knockDown && Random.Range(0, 2) < 1)
        {
            animation.KnockDown();

            if (health == 0.0f)
            {
                OnCharacterDeath();
            }
            else if (isPlayer)
            {
                Invoke("EnableEnemyManager", 3.0f);
                DisableEnemyManager();
            }
        }
        else if (health == 0.0f)
        {
            if (isPlayer)
            {
                OnCharacterDeath(true);
            }

            DisableEnemyManager();
            animation.Death();
        }
        else
        {
            animation.Hit();
        }
    }

    void OnCharacterDeath(bool ko = false)
    {
        slowMotion.Play(ko);
        dead = true;
    }

    void DisableEnemyManager()
    {
        if (isPlayer)
        {
            GameObject.FindWithTag(ObjectTags.ENEMY)
                .GetComponent<EnemyManager>().enabled = false;
        }
    }

    void EnableEnemyManager()
    {
        if (isPlayer)
        {
            GameObject.FindWithTag(ObjectTags.ENEMY)
                .GetComponent<EnemyManager>().enabled = true;
        }
    }
}
