using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deactivate : MonoBehaviour
{
    public float time = 1.0f;

    void Start()
    {
        Invoke("Hide", time);
    }

    void Hide()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
