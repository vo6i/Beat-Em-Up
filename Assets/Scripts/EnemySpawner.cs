using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField]
    private GameObject enemy;

    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
