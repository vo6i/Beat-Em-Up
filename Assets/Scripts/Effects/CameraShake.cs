using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float slowDown = 1.0f;
    public float duration = 0.2f;
    public float power    = 0.2f;

    private float startDuration;
    private Vector3 position;

    private void Start()
    {
        position = transform.localPosition;
        startDuration = duration;
    }

    private void Update()
    {
        if (!ShakeNow) return;

        if (duration > 0.0f)
        {
            transform.localPosition = position + Random.insideUnitSphere * power;
            duration -= Time.deltaTime * slowDown;
        }
        else
        {
            transform.localPosition = position;
            duration = startDuration;
            ShakeNow = false;
        }
    }

    public bool ShakeNow { set; get; }
}
