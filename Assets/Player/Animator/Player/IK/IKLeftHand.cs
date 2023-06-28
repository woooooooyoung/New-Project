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
        // 위치
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
        // 회전
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
    }
}
