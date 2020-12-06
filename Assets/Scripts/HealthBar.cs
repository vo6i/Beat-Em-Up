using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour
{
    private Image health;

    void Awake()
    {
        health = GameObject.FindWithTag(ObjectTags.HEALTH).GetComponent<Image>();
    }

    public void UpdateHealth(float value)
    {
        health.fillAmount = Math.Max(value / 100.0f, 0.0f);
    }
}
