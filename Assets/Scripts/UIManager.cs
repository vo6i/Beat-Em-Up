using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private float health = 1.0f;
    private Image healthBar;

    private void Awake()
    {
        healthBar = GameObject.FindWithTag(ObjectTag.HEALTH).GetComponent<Image>();
    }

    private void Update()
    {

        if (healthBar.fillAmount != health)
        {
            healthBar.fillAmount = Mathf.Lerp(
                healthBar.fillAmount, health, Time.deltaTime * 10.0f
            );
        }
    }

    public void UpdateHealthBar(float value)
    {
        health = Math.Max(value / 100.0f, 0.0f);
    }
}
