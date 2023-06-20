using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] bool deBug;

    [SerializeField] float moveSpeed;
    [SerializeField] float delayTime;


    private CharacterController characterController;
    private Vector3 moveDir;
    private Animator animator;

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
        characterController.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
        characterController.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);

        animator.SetFloat("XSpeed", moveDir.x, delayTime, Time.deltaTime);
        animator.SetFloat("YSpeed", moveDir.z, delayTime, Time.deltaTime);
        animator.SetFloat("TPSSpeed", 0f);


    }
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir = new Vector3(input.x, 0, input.y);
    }



}
