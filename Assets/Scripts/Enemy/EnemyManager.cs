using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;

    [SerializeField]
    private float attackDistance = 1.25f;

    private bool followPlayer, attackPlayer;
    private new AnimationManager animation;

    private float defaultAttack = 0.75f;
    private float chaseDistance = 0.25f;

    private Transform playerTarget;
    private float attackTime;
    private Rigidbody body;

    private void Awake()
    {
        playerTarget = GameObject.FindWithTag(ObjectTag.PLAYER).transform;
        animation = GetComponentInChildren<AnimationManager>();
        body = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        attackTime = defaultAttack;
        followPlayer = true;
    }

    private void Update()
    {
        if (attackPlayer)
        {
            Attack();
        }
    }

    private void Attack()
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

    private void FixedUpdate()
    {
        if (followPlayer)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
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

    void OnEnable()
    {
        body.detectCollisions = true;
        body.isKinematic = false;
    }

    void OnDisable()
    {
        body.detectCollisions = false;
        body.isKinematic = true;
    }

    public void Destroy()
    {
        Destroy(gameObject, 5.0f);
    }
}
