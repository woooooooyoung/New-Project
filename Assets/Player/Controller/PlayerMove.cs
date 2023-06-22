using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] bool deBug;

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float delayTime;

    private float moveSpeed;
    private CharacterController characterController;
    private Vector3 moveDir;
    private Animator animator;
    private bool isWalking;
    private bool isRun;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (moveDir.magnitude == 0)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, 0.5f);
        }
        else if (isRun)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, runSpeed, 0.5f);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, 0.5f);
        }

        characterController.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
        characterController.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);

        animator.SetFloat("XSpeed", moveDir.x, delayTime, Time.deltaTime);
        animator.SetFloat("YSpeed", moveDir.z, delayTime, Time.deltaTime);
        animator.SetFloat("FPSSpeed", moveSpeed);


    }
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir = new Vector3(input.x, 0, input.y);
    }
    private void OnRun(InputValue value)
    {
        isRun = value.isPressed;
    }



}
