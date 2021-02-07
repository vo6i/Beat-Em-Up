using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterHealth : MonoBehaviour
{
    public bool isPlayer;
    public float health = 100.0f;

    private bool dead = false;

    private UIManager uiManager;
    private SlowMotion slowMotion;
    private PlayerMovement movement;
    private new CharacterAnimation animation;

    void Awake()
    {
        animation = GetComponentInChildren<CharacterAnimation>();
        slowMotion = GetComponent<SlowMotion>();

        if (isPlayer)
        {
            movement = GetComponent<PlayerMovement>();
            uiManager = GetComponent<UIManager>();
        }
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (dead) return;
        health = Mathf.Max(health - damage, 0.0f);

        if (isPlayer)
        {
            uiManager.UpdateHealthBar(health);
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

        if (!isPlayer) enemy.Destroy();
        enemy.enabled = enable;
    }
}
