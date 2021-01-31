using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterAnimationDelegate : MonoBehaviour
{
    [SerializeField]
    private AudioClip whoosh, fall, hit, dead;
    private new CharacterAnimation animation;

    private EnemyManager enemyManager;
    private PlayerAttack playerAttack;

    private CameraShake cameraShake;
    private AudioSource audioSource;

    public GameObject leftArm, rightArm;
    public GameObject leftLeg, rightLeg;

    public float standUpTimer = 1.0f;

    void Awake()
    {
        cameraShake = GameObject.FindWithTag(ObjectTags.CAMERA).GetComponent<CameraShake>();
        animation = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();

        if (gameObject.CompareTag(ObjectTags.ENEMY))
        {
            enemyManager = GetComponentInParent<EnemyManager>();
        }
        else if (gameObject.CompareTag(ObjectTags.PLAYER))
        {
            playerAttack = GetComponentInParent<PlayerAttack>();
        }
    }

    void ActivateLeftArmAttack()
    {
        leftArm.SetActive(true);
    }

    void DeactivateLeftArmAttack()
    {
        if (leftArm.activeInHierarchy)
        {
            leftArm.SetActive(false);
        }
    }

    void ActivateRightArmAttack()
    {
        rightArm.SetActive(true);
    }

    void DeactivateRightArmAttack()
    {
        if (rightArm.activeInHierarchy)
        {
            rightArm.SetActive(false);
        }
    }

    void ActivateLeftLegAttack()
    {
        leftLeg.SetActive(true);
    }

    void DeactivateLeftLegAttack()
    {
        if (leftLeg.activeInHierarchy)
        {
            leftLeg.SetActive(false);
        }
    }

    void ActivateRightLegAttack()
    {
        rightLeg.SetActive(true);
    }

    void DeactivateRightLegAttack()
    {
        if (rightLeg.activeInHierarchy)
        {
            rightLeg.SetActive(false);
        }
    }

    void TagRightLeg()
    {
        rightLeg.tag = ObjectTags.RIGHT_LEG;
    }

    void UntagRightLeg()
    {
        rightLeg.tag = ObjectTags.UNTAGGED;
    }

    void TagLeftArm()
    {
        leftArm.tag = ObjectTags.LEFT_ARM;
    }

    void UntagLeftArm()
    {
        leftArm.tag = ObjectTags.UNTAGGED;
    }

    void TagLeftLeg()
    {
        leftLeg.tag = ObjectTags.LEFT_LEG;
    }

    void UntagLeftLeg()
    {
        leftLeg.tag = ObjectTags.UNTAGGED;
    }

    void EnemyStandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTimer);
        animation.StandUp();
    }

    public void AttackSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whoosh;
        audioSource.Play();
    }

    void KnockDownSound()
    {
        audioSource.clip = fall;
        audioSource.Play();
    }

    void HitGroundSound()
    {
        audioSource.clip = hit;
        audioSource.Play();
    }

    void DeathSound()
    {
        audioSource.volume = 1.0f;
        audioSource.clip = dead;
        audioSource.Play();
    }

    void DisablePlayerAttack()
    {
        playerAttack.enabled = false;
    }

    void EnablePlayerAttack()
    {
        playerAttack.enabled = true;
    }

    void DisableEnemyMovement()
    {
        transform.parent.gameObject.layer = 0;
        enemyManager.enabled = false;
    }

    void EnableEnemyMovement()
    {
        transform.parent.gameObject.layer = 9;
        enemyManager.enabled = true;
    }

    void ShakeCamera()
    {
        cameraShake.ShakeNow = true;
    }

    void CharacterDeath()
    {
        Invoke("DeactivateGameObject", 2.0f);
    }

    void DeactivateGameObject()
    {
        EnemySpawner.instance.Spawn();
        gameObject.SetActive(false);
        // Destroy(gameObject);
    }
}
