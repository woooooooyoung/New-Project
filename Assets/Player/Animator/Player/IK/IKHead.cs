using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHead : MonoBehaviour
{
    [SerializeField] Transform target;

    private Animator animator;
    [Range(0f, 1f)]
    public float h_Weight;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetLookAtPosition(target.position); // �ü�
        animator.SetLookAtWeight(h_Weight); // ���� ����ġ
    }

}
