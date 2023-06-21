using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : MonoBehaviour
{
   /* private CharacterController characterController;
    private Animator animator;

    public enum States { Walk, Run}
    private States states = States.Walk;

    private void Update()
    {
        switch (states)
        {
            case States.Walk:
                WalkUpdate();
                break;
            case States.Run:
                RunUpdate();
                break;
        }
    }
    private void Start()
    {
        OnWalk();
    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void WalkUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnRun();
        }
    }
    private void RunUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            OnWalk();
        }
    }
    private void OnRun()
    {
        animator.SetFloat("FPSSPeed", 3.5f);
    }
    private void OnWalk()
    {
        animator.SetFloat("FPSSPeed", 1f);
    }*/
}
