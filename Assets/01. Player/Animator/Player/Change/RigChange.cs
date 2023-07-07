using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigChange : MonoBehaviour
{
    // Rig의 가중치를 조절하는 스크립트
    [SerializeField] Rig rifleRig;
    [SerializeField] GameObject rifle;

    private void Awake()
    {
        rifleRig.weight = 0f;
    }
    private void Start()
    {
    }
    private void Update()
    {
        FPSRigChange();
    }
    private void FPSRigChange()
    {
        if (rifle.activeSelf)
        {
            rifleRig.weight = 1f;
        }
        else
        {
            rifleRig.weight = 0f;
        }
    }
}
