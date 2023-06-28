using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestEnemy : MonoBehaviour
{
    Transform target;
    NavMeshAgent navMeshAgent;
    Animator animator;

    float hp = 0;
    public float lostDistance;
    enum Enemy { Idle, Chase, Attack, Killed }
    Enemy enemy;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        hp = 10;
        enemy = Enemy.Idle;
        StartCoroutine(StateMachine());
    }
    IEnumerator StateMachine()
    {
        while (hp > 0)
        {
            yield return StartCoroutine(enemy.ToString());
        }
    }
    IEnumerator IDLE()
    {
        // ���� animator �������� ���
        var curAnimStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // �ִϸ��̼� �̸��� IdleNormal �� �ƴϸ� Play
        if (curAnimStateInfo.IsName("IdleNormal") == false)
            animator.Play("IdleNormal", 0, 0);

        // ���Ͱ� Idle ������ �� �θ��� �Ÿ��� �ϴ� �ڵ�
        // 50% Ȯ���� ��/��� ���� ����
        int dir = Random.Range(0f, 1f) > 0.5f ? 1 : -1;

        // ȸ�� �ӵ� ����
        float lookSpeed = Random.Range(25f, 40f);

        // IdleNormal ��� �ð� ���� ���ƺ���
        for (float i = 0; i < curAnimStateInfo.length; i += Time.deltaTime)
        {
            transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y + (dir) * Time.deltaTime * lookSpeed, 0f);

            yield return null;
        }
    }
    IEnumerator CHASE()
    {
        var curAnimStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (curAnimStateInfo.IsName("WalkFWD") == false)
        {
            animator.Play("WalkFWD", 0, 0);
            // SetDestination �� ���� �� frame�� �ѱ������ �ڵ�
            yield return null;
        }

        // ��ǥ������ ���� �Ÿ��� ���ߴ� �������� �۰ų� ������
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // StateMachine �� �������� ����
            ChangeState(Enemy.Attack);
        }
        // ��ǥ���� �Ÿ��� �־��� ���
        else if (navMeshAgent.remainingDistance > lostDistance)
        {
            target = null;
            navMeshAgent.SetDestination(transform.position);
            yield return null;
            // StateMachine �� ���� ����
            ChangeState(Enemy.Idle);
        }
        else
        {
            // WalkFWD �ִϸ��̼��� �� ����Ŭ ���� ���
            yield return new WaitForSeconds(curAnimStateInfo.length);
        }
    }

    IEnumerator ATTACK()
    {
        var curAnimStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // ���� �ִϸ��̼��� ���� �� Idle Battle �� �̵��ϱ� ������ 
        // �ڵ尡 �� ������ ���� ������ Attack01 �� Play
        animator.Play("Attack01", 0, 0);

        // �Ÿ��� �־�����
        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            // StateMachine�� �������� ����
            ChangeState(Enemy.Chase);
        }
        else
            // ���� animation �� �� �踸ŭ ���
            // �� ��� �ð��� �̿��� ���� ������ ������ �� ����.
            yield return new WaitForSeconds(curAnimStateInfo.length * 2f);
    }

    IEnumerator KILLED()
    {
        yield return null;
    }

    void ChangeState(Enemy newState)
    {
        enemy = newState;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") return;
        // Sphere Collider �� Player �� �����ϸ�      
        target = other.transform;
        // NavMeshAgent�� ��ǥ�� Player �� ����
        navMeshAgent.SetDestination(target.position);
        // StateMachine�� �������� ����
        ChangeState(Enemy.Chase);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        // target �� null �� �ƴϸ� target �� ��� ����
        navMeshAgent.SetDestination(target.position);
    }
}
