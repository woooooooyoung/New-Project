using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] bool deBugs;

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float delayTime;
    [SerializeField] float jumpSpeed;
    [SerializeField] float upperBodyMovement;

    //[SerializeField] float walkStepRange;
    //[SerializeField] float runStepRange;

    private Transform spine;
    private float moveSpeed;
    private float ySpeed = 0;
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
        switch (moveing)
        {
            case Moveing.Walk:
                WalkUpate();
                break;
            case Moveing.Run:
                RuningUpate();
                break;
        }
    }

    private void WalkUpate()
    {
        Debug.Log("Walk");
        if (moveDir.magnitude == 0)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, 0.5f);
        }
        else if (moveDir.magnitude > 0 || moveDir.magnitude < 0) // 좌표가 0보다 작거나 크면 움직이게 함
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, 0.5f);
        }
        if (isWalking)
        {
            Debug.Log("뛰고있음");
            if (moveDir.magnitude == 0)
            {
                moveSpeed = Mathf.Lerp(moveSpeed, 0, 0.5f); // 안움직이고 있을 땐 속도를 받지 않음(제거시 제자리에서 걷거나 뛰는 애니메이션 재생)
            }
            else
            {
                moveSpeed = runSpeed; // LiftShift를 눌렀을 때 받는속도 (걷는상태면 뛰고 뛰는상태면 걸어감)
            }
        }
        if (characterController.isGrounded)
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            moveDir = new Vector3(h, 0, v) * 1f;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            moveing = Moveing.Run;
        }

    }
    private void RuningUpate()
    {
        Debug.Log("Run");
        Debug.Log(moveDir);
        if (moveDir.magnitude == 0)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, 0.5f);
        }
        else if (moveDir.magnitude > 0 || moveDir.magnitude < 0)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, runSpeed, 0.5f);
        }
        if (isRun)
        {
            Debug.Log("걷고있음");
            if (moveDir.magnitude == 0)
            {
                moveSpeed = Mathf.Lerp(moveSpeed, 0, 0.5f);
            }
            else
            {
                moveSpeed = walkSpeed;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            moveing = Moveing.Walk;
        }
    }
    private bool GroundCheck()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position + Vector3.up * 1, 0.5f, Vector3.down, out hit, 0.6f);
    }
    //private void OnDrawGizmosSelected()
    //{
    //    if (!deBugs)
    //        return;
    //
    //    Gizmos.color = Color.cyan;
    //    Gizmos.DrawWireSphere(transform.position, walkStepRange);
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(transform.position, runStepRange);
    //}
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

