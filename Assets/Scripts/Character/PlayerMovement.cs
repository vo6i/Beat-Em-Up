using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    // private float horizontalRotation = -90.0f;
    // private float verticalRotation = -180.0f;

    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 1.5f;

    private CharacterAnimation animation;
    private Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        animation = GetComponentInChildren<CharacterAnimation>();
    }

    void Update()
    {
        UpdatePlayerRotation();
        UpdatePlayerAnimation();
    }

    private void UpdatePlayerRotation()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL) == 1)
        {
            transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL) == -1)
        {
            transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        }


        if (Input.GetAxisRaw(Axis.VERTICAL) == 1)
        {
            transform.rotation = Quaternion.Euler(0.0f, -180.0f, 0.0f);
        }
        else if (Input.GetAxisRaw(Axis.VERTICAL) == -1)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }

    private void UpdatePlayerAnimation()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL) != 0 || Input.GetAxisRaw(Axis.VERTICAL) != 0)
        {
            animation.Walk(true);
        }
        else
        {
            animation.Walk(false);
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL) * -horizontalSpeed,
            body.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL) * -verticalSpeed
        );
    }
}
