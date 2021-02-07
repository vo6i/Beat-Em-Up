using UnityEngine;

public class AttackManager : MonoBehaviour
{
    private enum ComboState { NONE, PUNCH1, PUNCH2, PUNCH3, KICK1, KICK2 }
    private ComboState comboState = ComboState.NONE;

    private new AnimationManager animation;
    private float defaultTimer = 0.33f;

    private bool activeTimer = false;
    private float comboTimer = 0.0f;

    private void Awake()
    {
        animation = GetComponentInChildren<AnimationManager>();
    }

    private void Start()
    {
        comboState = ComboState.NONE;
        comboTimer = defaultTimer;
    }

    private void Update()
    {
        CheckComboAttacks();
        ResetComboState();
    }

    private void CheckComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnPunchAttack();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            OnKickAttack();
        }
    }

    private void OnPunchAttack()
    {
        if (comboState > (ComboState) 2)
        {
            return;
        }

        comboTimer = defaultTimer;
        activeTimer = true;
        comboState++;

        if (comboState == ComboState.PUNCH1)
        {
            animation.Punch1();
        }

        if (comboState == ComboState.PUNCH2)
        {
            animation.Punch2();
        }

        if (comboState == ComboState.PUNCH3)
        {
            animation.Punch3();
        }
    }

    private void OnKickAttack()
    {
        if (comboState == ComboState.PUNCH3 || comboState == ComboState.KICK2)
        {
            return;
        }

        if (comboState < (ComboState) 3)
        {
            comboState = ComboState.KICK1;
        }
        else if (comboState == ComboState.KICK1)
        {
            comboState++;
        }

        comboTimer = defaultTimer;
        activeTimer = true;

        if (comboState == ComboState.KICK1)
        {
            animation.Kick1();
        }
        else if (comboState == ComboState.KICK2)
        {
            animation.Kick2();
        }
    }

    private void ResetComboState()
    {
        if (activeTimer)
        {
            comboTimer -= Time.deltaTime;

            if (comboTimer <= 0.0f)
            {
                comboState = ComboState.NONE;
                comboTimer = defaultTimer;
                activeTimer = false;
            }
        }
    }
}
