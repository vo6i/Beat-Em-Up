using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField]
    private float duration = 1.0f;

    private void Start()
    {
        Invoke("Destroy", duration);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
