using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHead : MonoBehaviour
{
    [SerializeField] Transform target;

    private Animator animator;
    private float weight = 1.0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetLookAtPosition(target.position);
        animator.SetLookAtWeight(weight); // 성능 가중치
    }

}
