using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class TPSMove : MonoBehaviour
{
    [SerializeField] float dashSpeed;   // �뽬�ӵ�
    [SerializeField] float dashTime;    // �뽬������ �ð�
    [SerializeField] float agentSpeed;  // �뽬 �� �ӵ�
    [SerializeField] float coolTime;    // �뽬 ��Ÿ��
    [SerializeField] float acceleration;    // �뽬�� ���ӵ�
    [SerializeField] float accelerationUp;  // �뽬���ӵ�
    [SerializeField] float dashAnimTime; // �뽬�ϴ� ���� �ִϸ��̼� ����ð�
    [SerializeField] float dashAnimSpeed; // �뽬 �ִϸ��̼� ���Կ� �ʿ��� �ӵ�

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
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) // ���콺 ��Ŭ��, ��Ŭ������ �̵�
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
        if (agent.remainingDistance < 0.1f)         // ���������� ���� �Ÿ��� 0.1���� ������ ������
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
    private void DashAnimatorOn()   // �뽬�� �ӵ��� ������� �뽬�ִϸ��̼� ����
    {
        animator.SetFloat("TPSAnimSpeed", dashAnimSpeed);
    }
    private void DashAnimatorOff()  // �뽬�ִϸ��̼ǿ��� ����������
    {
        animator.SetFloat("TPSAnimSpeed", 0f);
    }
    private void DashSpeedUp()      // �뽬�ӵ�
    {
        agent.speed = dashSpeed;
        agent.updateRotation = false; // �뽬�ϴµ��� ȸ�� ����
    }
    private void DashSpeedDown()    // �뽬���� �� �����ӵ�
    {
        agent.speed = agentSpeed;
        agent.updateRotation = true; // �뽬 ���� �� ȸ�� Ǯ��
    }
    private void AccelerationUP()   // �뽬�ϴµ��� ���ӵ� ����
    {
        agent.acceleration = accelerationUp;
    }
    private void AccelerationDown() // �뽬�ϱ��� ���ӵ��� ���ư�
    {
        agent.acceleration = acceleration;
    }
    private void AgentSpeed()       // �뽬�ϱ��� �ӵ�����
    {
        agent.speed = agentSpeed;
    }
    private void Acceleration()     // �뽬�ϱ����� ���ӵ� ����
    {
        agent.acceleration = acceleration;
    }
    public void StopNavMeshAgent()
    {
        agent.enabled = false;
    }

}


