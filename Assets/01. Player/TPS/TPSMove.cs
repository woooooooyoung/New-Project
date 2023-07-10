using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class TPSMove : MonoBehaviour
{
    [SerializeField] float dashSpeed;   // 대쉬속도
    [SerializeField] float dashTime;    // 대쉬끝나는 시간
    [SerializeField] float agentSpeed;  // 대쉬 전 속도
    [SerializeField] float coolTime;    // 대쉬 쿨타임
    [SerializeField] float acceleration;    // 대쉬전 가속도
    [SerializeField] float accelerationUp;  // 대쉬가속도
    [SerializeField] float dashAnimTime; // 대쉬하는 동안 애니메이션 재생시간
    [SerializeField] float dashAnimSpeed; // 대쉬 애니메이션 진입에 필요한 속도

    private Animator animator;
    private bool isCoolTime;
    private NavMeshAgent agent;
    private float time = 0f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Dash();
        PlayerStop();
    }

    private void Start()
    {
        IdleOn();
        AgentSpeed();
        Acceleration();
    }
    private void Dash()
    {
        PlayerMove();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isCoolTime)
            {
                isCoolTime = true;
                DashSpeedUp();
                AccelerationUP();
                DashAnimatorOn();
                Invoke("DashAnimatorOff", dashAnimTime);
                Invoke("DashSpeedDown", dashTime);
                Invoke("AccelerationDown", dashTime);
            }
        }
        if (isCoolTime)
        {
            time += Time.deltaTime;
            if (time >= coolTime)
            {
                time = 0f;
                isCoolTime = false;
            }
        }
    }
    private void PlayerMove()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) // 마우스 우클릭, 좌클릭으로 이동
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
                animator.SetFloat("TPSSpeed", 2.0f);

                Vector3 clickPoint = hit.point;

                transform.LookAt(new Vector3(clickPoint.x, transform.position.y, clickPoint.z));
            }
        }
        if (agent.remainingDistance < 0.1f)         // 목적지까지 남은 거리가 0.1보다 작으면 도착함
        {
            animator.SetFloat("TPSSpeed", 0f);
        }
    }
    private void PlayerStop()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("TPSSpeed", 0f);
            agent.ResetPath();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetFloat("TPSSpeed", 2f);
            AgentSpeed();
        }
    }
    private void IdleOn()
    {
        animator.StopPlayback();
    }
    private void DashAnimatorOn()   // 대쉬의 속도와 상관없이 대쉬애니메이션 진입
    {
        animator.SetFloat("TPSAnimSpeed", dashAnimSpeed);
    }
    private void DashAnimatorOff()  // 대쉬애니메이션에서 빠져나오기
    {
        animator.SetFloat("TPSAnimSpeed", 0f);
    }
    private void DashSpeedUp()      // 대쉬속도
    {
        agent.speed = dashSpeed;
        agent.updateRotation = false; // 대쉬하는동안 회전 막기
    }
    private void DashSpeedDown()    // 대쉬끝난 후 원래속도
    {
        agent.speed = agentSpeed;
        agent.updateRotation = true; // 대쉬 끝난 후 회전 풀기
    }
    private void AccelerationUP()   // 대쉬하는동안 가속도 증가
    {
        agent.acceleration = accelerationUp;
    }
    private void AccelerationDown() // 대쉬하기전 가속도로 돌아감
    {
        agent.acceleration = acceleration;
    }
    private void AgentSpeed()       // 대쉬하기전 속도보관
    {
        agent.speed = agentSpeed;
    }
    private void Acceleration()     // 대쉬하기전의 가속도 보관
    {
        agent.acceleration = acceleration;
    }
    public void StopNavMeshAgent()
    {
        agent.enabled = false;
    }

}


