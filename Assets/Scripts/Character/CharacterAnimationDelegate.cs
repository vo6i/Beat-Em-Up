using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterAnimationDelegate : MonoBehaviour
{
    private new CharacterAnimation animation;

    public GameObject leftArm, rightArm;
    public GameObject leftLeg, rightLeg;

    public float standUpTimer = 1.0f;

    void Awake()
    {
        animation = GetComponent<CharacterAnimation>();
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
}
