using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public bool Shaking { set; get; }

    public float rightBound = -10.0f;
    public float leftBound  = 7.15f;

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
        if (Shaking)
        {
            Shake();
        }
        else
        {
            Follow();
        }
    }

    private void Shake()
    {
        if (duration > 0.0f)
        {
            transform.position = position + Random.insideUnitSphere * power;
            duration -= Time.deltaTime * slowDown;
        }
        else
        {
            transform.position = position;
            duration = startDuration;
            Shaking = false;
        }
    }

    private void Follow()
    {
        Vector3 position = transform.position;
        float target = player.transform.position.x;

        position.x = Mathf.Clamp(target, rightBound, leftBound);

        transform.position = position;
        this.position.x = position.x;
    }
}
