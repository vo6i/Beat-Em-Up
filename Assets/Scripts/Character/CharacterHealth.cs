using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterHealth : MonoBehaviour
{
    private new CharacterAnimation animation;
    private PlayerMovement movement;
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
            movement = GetComponent<PlayerMovement>();
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
                movement.knockDown = true;
                ToggleEnemyManager(false);
            }
        }
        else if (health == 0.0f)
        {
            OnCharacterDeath(isPlayer);
            ToggleEnemyManager(false);
            animation.Death();
        }
        else
        {
            int type = isPlayer ? 1 : 0;
            animation.Hit(type);
        }
    }

    void OnCharacterDeath(bool ko = false)
    {
        dead = true;
        slowMotion.Play(ko);
    }

    public void ToggleEnemyManager(bool enable)
    {
        EnemyManager enemy = GameObject
            .FindWithTag(ObjectTags.ENEMY)
            .GetComponent<EnemyManager>();

        enemy.enabled = enable;
        if (!isPlayer) enemy.Destroy();
    }
}
