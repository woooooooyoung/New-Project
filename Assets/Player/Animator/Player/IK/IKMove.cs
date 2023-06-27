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


            RaycastHit hit; // ����ĳ��Ʈ ��� ����
            Ray ray = new Ray(animator.GetIKPosition(AvatarIKGoal.LeftFoot)+ Vector3.up, Vector3.down); // ����ĳ��Ʈ ����, �޹��� ��ġ�� �� �� �ְ� �׻� �ʿ��� ��ġ�� �ִϸ��̼��� ��ġ
            // ��ֹ��� ���� ��ó�� �ٴ� �Ʒ��� �ְ� ���� �ٴ� �Ʒ��� ������ ���� ������ ��ġ�� ������ ���ϰ� ���� �ٴڿ� �ӹ��� ��
            // ���� -> ����
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

            ray = new Ray(animator.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down); // ����ĳ��Ʈ ����, �޹��� ��ġ�� �� �� �ְ� �׻� �ʿ��� ��ġ�� �ִϸ��̼��� ��ġ
            // ��ֹ��� ���� ��ó�� �ٴ� �Ʒ��� �ְ� ���� �ٴ� �Ʒ��� ������ ���� ������ ��ġ�� ������ ���ϰ� ���� �ٴڿ� �ӹ��� ��
            // ���� -> ����
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
