using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHand : MonoBehaviour
{
    private Animator animator;

    public Transform leftHand;

    public Transform righftHand;

    [Range(0,1f)]
    public float l_Weight;
    [Range(0, 1f)]
    public float r_Weight;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        // 위치
        //왼손
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, l_Weight);

        //오른손
        animator.SetIKPosition(AvatarIKGoal.RightHand, righftHand.position);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, r_Weight);

        // 회전
        //왼손
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, l_Weight);


        //오른손
        animator.SetIKRotation(AvatarIKGoal.RightHand, righftHand.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, r_Weight);
    }
}
