using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKLeftHand : MonoBehaviour
{
    public Transform leftHandObj;
    private Animator animator;

    [Range(0, 1f)]
    public float weight;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        // ��ġ
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
        // ȸ��
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
    }
}
