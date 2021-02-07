using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private new CharacterAnimation animation;
    private bool followPlayer, attackPlayer;

    public float attackDistance = 1.25f;
    private float defaultAttack = 0.75f;
    private float chaseDistance = 0.25f;

    private Transform playerTarget;
    public float speed = 2.0f;

    private float attackTime;
    private Rigidbody body;

    void Awake()
    {
        playerTarget = GameObject.FindWithTag(ObjectTags.PLAYER).transform;
        animation = GetComponentInChildren<CharacterAnimation>();
        body = GetComponent<Rigidbody>();
    }

    void Start()
    {
        attackTime = defaultAttack;
        followPlayer = true;
    }

    void Update()
    {
        if (attackPlayer)
        {
            Attack();
        }
    }

    void Attack()
    {
        float followDistance = attackDistance + chaseDistance;
        attackTime += Time.deltaTime;

        if (attackTime > defaultAttack)
        {
            animation.EnemyAttack(Random.Range(0, 3));
            attackTime = 0.0f;
        }

        if (DistanceToPlayer() > followDistance)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }

    void FixedUpdate()
    {
        if (followPlayer)
        {
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        if (DistanceToPlayer() > attackDistance)
        {
            body.velocity = transform.forward * speed;
            if (!attackPlayer) animation.Walk(true);
            transform.LookAt(playerTarget);
        }
        else
        {
            body.velocity = Vector3.zero;
            animation.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, playerTarget.position);
    }

    public void Destroy()
    {
        Destroy(gameObject, 5.0f);
    }
}
