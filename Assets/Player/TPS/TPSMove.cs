using System.Collections;
using System.Collections.Generic;
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
    }

    private void Start()
    {
        AgentSpeed();
        Acceleration();
    }
    private void Dash()
    {
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
    }
    private void DashSpeedDown()    // �뽬���� �� �����ӵ�
    {
        agent.speed = agentSpeed;
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
}
