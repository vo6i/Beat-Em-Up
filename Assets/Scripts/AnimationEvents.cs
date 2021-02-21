using UnityEngine;
using System.Collections;

public class AnimationEvents : MonoBehaviour
{
    public GameObject leftArm, rightArm, leftLeg, rightLeg;

    [SerializeField]
    private AudioClip whoosh, fall, hit, dead;

    [SerializeField]
    private float standUpTimer = 1.0f;

    private new AnimationManager animation;
    private CameraManager cameraManager;

    private AttackManager playerAttack;
    private EnemyManager enemyManager;
    private AudioSource audioSource;
    
    private void Awake()
    {
        cameraManager = GameObject.FindWithTag(ObjectTag.CAMERA)
                            .GetComponent<CameraManager>();

        animation = GetComponent<AnimationManager>();
        audioSource = GetComponent<AudioSource>();

        if (gameObject.CompareTag(ObjectTag.ENEMY))
        {
            enemyManager = GetComponentInParent<EnemyManager>();
        }
        else if (gameObject.CompareTag(ObjectTag.PLAYER))
        {
            playerAttack = GetComponentInParent<AttackManager>();
        }
    }

    private void ActivateLeftArmAttack()
    {
        leftArm.SetActive(true);
    }

    private void DeactivateLeftArmAttack()
    {
        if (leftArm.activeInHierarchy)
        {
            leftArm.SetActive(false);
        }
    }

    private void ActivateRightArmAttack()
    {
        rightArm.SetActive(true);
    }

    private void DeactivateRightArmAttack()
    {
        if (rightArm.activeInHierarchy)
        {
            rightArm.SetActive(false);
        }
    }

    private void ActivateLeftLegAttack()
    {
        leftLeg.SetActive(true);
    }

    private void DeactivateLeftLegAttack()
    {
        if (leftLeg.activeInHierarchy)
        {
            leftLeg.SetActive(false);
        }
    }

    private void ActivateRightLegAttack()
    {
        rightLeg.SetActive(true);
    }

    private void DeactivateRightLegAttack()
    {
        if (rightLeg.activeInHierarchy)
        {
            rightLeg.SetActive(false);
        }
    }

    private void TagLeftArm()
    {
        leftArm.tag = ObjectTag.LEFT_ARM;
    }

    private void UntagLeftArm()
    {
        leftArm.tag = ObjectTag.UNTAGGED;
    }

    private void TagLeftLeg()
    {
        leftLeg.tag = ObjectTag.LEFT_LEG;
    }

    private void UntagLeftLeg()
    {
        leftLeg.tag = ObjectTag.UNTAGGED;
    }

    private void TagRightLeg()
    {
        rightLeg.tag = ObjectTag.RIGHT_LEG;
    }

    private void UntagRightLeg()
    {
        rightLeg.tag = ObjectTag.UNTAGGED;
    }

    private void EnablePlayerAttack()
    {
        playerAttack.enabled = true;
    }
    private void DisablePlayerAttack()
    {
        playerAttack.enabled = false;
    }

    private void EnableEnemyMovement()
    {
        transform.parent.gameObject.layer = 9;
        enemyManager.enabled = true;
    }

    private void DisableEnemyMovement()
    {
        transform.parent.gameObject.layer = 0;
        enemyManager.enabled = false;
    }

    private void EnemyStandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    private IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTimer);
        animation.StandUp();
    }

    private void CharacterDeath()
    {
        Invoke("DeactivateGameObject", 2.0f);
    }

    private void DeactivateGameObject()
    {
        EnemySpawner.instance.Spawn();
        gameObject.SetActive(false);
    }

    private void ShakeCamera()
    {
        cameraManager.Shaking = true;
    }

    private void AttackSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whoosh;
        audioSource.Play();
    }

    private void KnockDownSound()
    {
        audioSource.clip = fall;
        audioSource.Play();
    }

    private void HitGroundSound()
    {
        audioSource.clip = hit;
        audioSource.Play();
    }

    private void DeathSound()
    {
        audioSource.volume = 1.0f;
        audioSource.clip = dead;
        audioSource.Play();
    }
}
