using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public bool isPlayer;
    public float health = 100.0f;

    private new AnimationManager animation;
    private SlowMotion slowMotion;

    private MovementManager movement;
    private UIManager uiManager;

    private bool dead = false;

    private void Awake()
    {
        animation = GetComponentInChildren<AnimationManager>();
        slowMotion = GetComponent<SlowMotion>();

        if (isPlayer)
        {
            movement = GetComponent<MovementManager>();
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
                movement.KnockDown = true;
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

    private void OnCharacterDeath(bool ko = false)
    {
        dead = true;
        slowMotion.Play(ko);
    }

    public void ToggleEnemyManager(bool enable)
    {
        EnemyManager enemy = GameObject
            .FindWithTag(ObjectTag.ENEMY)
            .GetComponent<EnemyManager>();

        if (!isPlayer) enemy.Destroy();
        enemy.enabled = enable;
    }
}
