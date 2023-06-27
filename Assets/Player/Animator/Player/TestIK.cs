using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestIK : MonoBehaviour
{
    private Animator animator;
    public bool ikActive = false; // ik의 활동은 거짓
    public Transform aimTarget = null;    // 오브젝트 보기
    //public Transform rightHandObj = null; // 오른손 오브젝트
    //public Transform lefrHandObj = null;  // 왼손 오브젝트 
    //public Transform spines = null;
    //public Transform aime = null;
    //[SerializeField] Transform target; // 바라볼 타겟

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    //IK 계산을 위한 콜백
    void OnAnimatorIK()
    {
        if (animator)
        {
            //IK가 활성화된 경우 위치와 회전을 목표에 직접 설정합니다. 
            if (ikActive)
            {
                // 대상 위치가 할당된 경우 대상 위치
                if (aimTarget != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(aimTarget.position);
                }
                // 오른쪽 표적 위치 및 회전 설정(할당된 경우)
                //if (rightHandObj != null)
                //{
                //
                //    //animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                //    //animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                //    //animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                //    //animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                //}

            }
            //IK가 활성화되지 않은 경우 손과 머리의 위치와 회전을 원래 위치로 설정합니다
            else
            {
                //animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                //animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }
    /*public Transform target; // 회전의 중심이 되는 대상(게임 오브젝트)의 Transform

private float rotationSpeed = 5f; // 회전 속도

private void Update()
{
    // 수평 및 수직 입력을 받아서 회전할 각도를 계산
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    float rotationAngle = rotationSpeed * horizontalInput * Time.deltaTime;

    // 대상(게임 오브젝트)을 회전시킴
    target.Rotate(Vector3.up, rotationAngle);

    // 카메라도 함께 회전시킴
    transform.Rotate(Vector3.up, rotationAngle);
}*/
}


