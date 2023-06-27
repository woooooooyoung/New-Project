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
        // ��ġ
        //�޼�
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

        //������
        animator.SetIKPosition(AvatarIKGoal.RightHand, righftHand.position);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);

        // ȸ��
        //�޼�
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);


        //������
        animator.SetIKRotation(AvatarIKGoal.RightHand, righftHand.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
    }
}
