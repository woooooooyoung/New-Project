using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IKMoveing : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float delayTime;
    private float ySpeed = 0;
    public float walkStepRange;
    public float runStepRange;
    bool isRun;
    bool isWalking;
    bool deBugs;

    CharacterController characterController;
    Animator animator;
    Vector3 moveDir;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Move()
    {
        /*if (moveDir.magnitude == 0)                           // 안움직이면 속도를 안줌
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, 0.5f);
        }
        else if (isRun)                                         // 달리기
        {
            moveSpeed = Mathf.Lerp(moveSpeed, runSpeed, 0.5f);
        }
        else                                                    // 걷기
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, 0.5f);
        }*/

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
    private void OnWalk(InputValue value)
    {
        isWalking = value.isPressed;
    }
    public enum Moveing { Walk, Run }
    private Moveing moveing = Moveing.Walk;

    private void Update()
    {
        Move();
        Jump();
    }

    private bool GroundCheck()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position + Vector3.up * 1, 0.5f, Vector3.down, out hit, 0.6f);
    }
    private void OnDrawGizmosSelected()
    {
        if (!deBugs)
            return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, walkStepRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, runStepRange);
    }
    private void Jump()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (GroundCheck() && ySpeed < 0)
            ySpeed = 0;
        characterController.Move(Vector3.up * ySpeed * Time.deltaTime);
    }
    private void OnJump(InputValue value)
    {
        if (GroundCheck())
            ySpeed = jumpSpeed;
    }
}
