using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IKMove : MonoBehaviour
{
    private Animator animator;

    public LayerMask layerMask;
    public Transform leftFoot;
    public Transform rightFoot;
    [Range (0, 1f)]
    public float DistanceToGroung;

    private void OnAnimatorIK(int layerIndex)
    {
        if (animator) 
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1f);


            RaycastHit hit; // 레이캐스트 결과 저장
            Ray ray = new Ray(animator.GetIKPosition(AvatarIKGoal.LeftFoot)+ Vector3.up, Vector3.down); // 레이캐스트 생성, 왼발의 위치를 알 수 있고 항상 필요한 위치가 애니메이션의 위치
            // 장애물을 밟은 것처럼 바닥 아래에 있고 발이 바닥 아래에 있으면 진행 지형을 놓치면 감지를 못하고 발은 바닥에 머물게 됨
            // 저장 -> 생성
            if (Physics.Raycast(ray, out hit, DistanceToGroung + 1f, layerMask))
            {
                if (hit.transform.tag == "Walkable")
                {
                    Vector3 footPositon = hit.point;
                    footPositon.y += DistanceToGroung;
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, footPositon);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward, hit.normal));
                }
            }

            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1f);

            ray = new Ray(animator.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down); // 레이캐스트 생성, 왼발의 위치를 알 수 있고 항상 필요한 위치가 애니메이션의 위치
            // 장애물을 밟은 것처럼 바닥 아래에 있고 발이 바닥 아래에 있으면 진행 지형을 놓치면 감지를 못하고 발은 바닥에 머물게 됨
            // 저장 -> 생성
            if (Physics.Raycast(ray, out hit, DistanceToGroung + 1f, layerMask))
            {
                if (hit.transform.tag == "Walkable")
                {
                    Vector3 footPositon = hit.point;
                    footPositon.y += DistanceToGroung;
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, footPositon);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(transform.forward, hit.normal));
                }
            }
        }
    }
}
