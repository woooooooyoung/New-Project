using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKRightHand : MonoBehaviour
{
    public Transform righthandObj;
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
        animator.SetIKPosition(AvatarIKGoal.RightHand, righthandObj.position);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
        // ȸ��
        animator.SetIKRotation(AvatarIKGoal.RightHand, righthandObj.rotation);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
    }
}
