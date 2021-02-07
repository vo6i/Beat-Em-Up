using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public bool isPlayer, isEnemy;
    public GameObject hitEffect;
    public LayerMask layerMask;

    public float radius = 1.0f;
    public float damage = 5.0f;

    private void Update()
    {
        Collider[] hit = Physics.OverlapSphere(
            transform.position, radius, layerMask
        );

        if (hit.Length > 0)
        {
            bool knockDown = isEnemy && gameObject.CompareTag(ObjectTag.RIGHT_LEG);

            if (isPlayer)
            {
                knockDown = gameObject.CompareTag(ObjectTag.LEFT_ARM) ||
                            gameObject.CompareTag(ObjectTag.LEFT_LEG);

                Vector3 hitPosition = hit[0].transform.position;
                bool right = hit[0].transform.forward.x < 0;

                hitPosition.x += right ? -0.25f : 0.25f;
                hitPosition.y += 1.25f;

                Instantiate(hitEffect, hitPosition, Quaternion.identity);
            }

            hit[0].GetComponent<HealthManager>().ApplyDamage(damage, knockDown);
            gameObject.SetActive(false);
        }
    }
}
