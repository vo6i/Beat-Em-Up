using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterAttack : MonoBehaviour
{
    public bool isPlayer, isEnemy;
    public GameObject hitEffect;
    public LayerMask layerMask;

    public float radius = 1.0f;
    public float damage = 2.0f;

    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(
            transform.position, radius, layerMask
        );

        if (hit.Length > 0)
        {
            if (isPlayer)
            {
                bool knockDown = gameObject.CompareTag(ObjectTags.LEFT_ARM) ||
                                 gameObject.CompareTag(ObjectTags.LEFT_LEG);

                Vector3 hitPosition = hit[0].transform.position;
                bool right = hit[0].transform.forward.x < 0;

                hitPosition.x += right ? -0.25f : 0.25f;
                hitPosition.y += 1.25f;

                Instantiate(hitEffect, hitPosition, Quaternion.identity);
                hit[0].GetComponent<CharacterHealth>().ApplyDamage(damage, knockDown);
            }

            gameObject.SetActive(false);
        }
    }
}
