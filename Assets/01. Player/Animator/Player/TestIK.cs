using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestIK : MonoBehaviour
{
    private Animator animator;
    public bool ikActive = false; // ik�� Ȱ���� ����
    public Transform aimTarget = null;    // ������Ʈ ����
    //public Transform rightHandObj = null; // ������ ������Ʈ
    //public Transform lefrHandObj = null;  // �޼� ������Ʈ 
    //public Transform spines = null;
    //public Transform aime = null;
    //[SerializeField] Transform target; // �ٶ� Ÿ��

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    //IK ����� ���� �ݹ�
    void OnAnimatorIK()
    {
        if (animator)
        {
            //IK�� Ȱ��ȭ�� ��� ��ġ�� ȸ���� ��ǥ�� ���� �����մϴ�. 
            if (ikActive)
            {
                // ��� ��ġ�� �Ҵ�� ��� ��� ��ġ
                if (aimTarget != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(aimTarget.position);
                }
                // ������ ǥ�� ��ġ �� ȸ�� ����(�Ҵ�� ���)
                //if (rightHandObj != null)
                //{
                //
                //    //animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                //    //animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                //    //animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                //    //animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                //}

            }
            //IK�� Ȱ��ȭ���� ���� ��� �հ� �Ӹ��� ��ġ�� ȸ���� ���� ��ġ�� �����մϴ�
            else
            {
                //animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                //animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }
    /*public Transform target; // ȸ���� �߽��� �Ǵ� ���(���� ������Ʈ)�� Transform

private float rotationSpeed = 5f; // ȸ�� �ӵ�

private void Update()
{
    // ���� �� ���� �Է��� �޾Ƽ� ȸ���� ������ ���
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    float rotationAngle = rotationSpeed * horizontalInput * Time.deltaTime;

    // ���(���� ������Ʈ)�� ȸ����Ŵ
    target.Rotate(Vector3.up, rotationAngle);

    // ī�޶� �Բ� ȸ����Ŵ
    transform.Rotate(Vector3.up, rotationAngle);
}*/
}


