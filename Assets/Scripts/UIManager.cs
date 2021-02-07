using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Image healthBar;

    private void Awake()
    {
        healthBar = GameObject.FindWithTag(ObjectTags.HEALTH).GetComponent<Image>();
    }

    public void UpdateHealthBar(float value)
    {
        healthBar.fillAmount = Math.Max(value / 100.0f, 0.0f);
    }
}
