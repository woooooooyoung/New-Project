using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHand : MonoBehaviour
{
    [SerializeField] Transform tergat;
    
    private Animator animator;

    public Transform leftHand;
    public Transform righftHand;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        // 위치
        //왼손
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

        //오른손
        animator.SetIKPosition(AvatarIKGoal.RightHand, righftHand.position);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);

        // 회전
        //왼손
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);


        //오른손
        animator.SetIKRotation(AvatarIKGoal.RightHand, righftHand.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
    }
}
