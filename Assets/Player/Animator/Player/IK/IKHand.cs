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
        // ��ġ
        //�޼�
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, l_Weight);

        //������
        animator.SetIKPosition(AvatarIKGoal.RightHand, righftHand.position);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, r_Weight);

        // ȸ��
        //�޼�
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, l_Weight);


        //������
        animator.SetIKRotation(AvatarIKGoal.RightHand, righftHand.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, r_Weight);
    }
}
