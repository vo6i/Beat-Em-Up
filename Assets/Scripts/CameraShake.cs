using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraShake : MonoBehaviour
{
    public float slowDown = 1.0f;
    public float duration = 0.2f;
    public float power = 0.2f;

    private float startDuration;
    private Vector3 position;
    private bool shakeNow;

    void Start()
    {
        position = transform.localPosition;
        startDuration = duration;
    }

    void Update()
    {
        Shake();
    }

    void Shake()
    {
        if (!shakeNow) return;

        if (duration > 0.0f)
        {
            transform.localPosition = position + Random.insideUnitSphere * power;
            duration -= Time.deltaTime * slowDown;
        }
        else
        {
            transform.localPosition = position;
            duration = startDuration;
            shakeNow = false;
        }
    }

    public bool ShakeNow
    {
        set
        {
            shakeNow = value;
        }

        get
        {
            return shakeNow;
        }
    }
}
