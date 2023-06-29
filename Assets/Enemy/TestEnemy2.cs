using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TestEnemy2 : MonoBehaviour
{
    public bool deBug;

    public int maxHealth;
    public int curHealth;
    public float lostDistance;
    public Transform target;
    public bool isChase;
    public int hp;

    Material mat;
    Animator animator;
    NavMeshAgent agent;
    CharacterController characterController;
    Rigidbody rigidbody;

    private EnemyState currentState;

    public enum EnemyState { Idle, Chase, Attack, Die }

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        currentState = EnemyState.Idle;
        // 시작
        StartCoroutine(StateMachine());
    }
    private void Update()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }
    private void ChangeState(EnemyState nextState)
    {
        currentState = nextState;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") // Player이라는 이름이 콜라이더의 트리거 안에 없음
        {
            return;
        }
        else
        {
            target = other.transform;
            agent.SetDestination(target.position); // Player를 따라감
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            
        }
    }
    private IEnumerator StateMachine()
    {
        
        while (hp > 0)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }
    private IEnumerable Idle()
    {
        target = null;
        
        
        
        yield break;
    }
    private IEnumerable Chase()
    {
        // 목표까지의 남은 거리가 멈추는 지점보다 작거나 같으면
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            // StateMachine 을 공격으로 변경
            //ChangeState(State.ATTACK);
        }
        // 목표와의 거리가 멀어진 경우
        else if (agent.remainingDistance > lostDistance)
        {
            target = null;
            agent.SetDestination(transform.position);
            yield return null;
            // StateMachine 을 대기로 변경
            ChangeState(EnemyState.Idle);
        }
        yield break;
    }
    private IEnumerable Attack()
    { yield break; }
    private IEnumerable Die()
    { yield break; }
    private void OnDrawGizmosSelected()
    {
        if (!deBug)
            return;


        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lostDistance);
    }
}































    /*//private Enamy enamy = Enamy.Idle;
*//*    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        characterController = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();

        //Invoke("ChaseStart", 2);
    }*//*
    private void FreezeRotation()
    {
        if(isChase)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    } 
    private void IdleStart()
    {
        Debug.Log("1");
        isChase = false;
        animator.SetBool("isWalk", false);

        if (target == null) 
        {
            return;
        }
        else
        {
            enamy = Enamy.Chase;
        }
    }
    private void ChaseStart()
    {
        Debug.Log("2");
        isChase = true;
        animator.SetBool("isWalk", true);
        if (!target == null) 
        {
            return;
        }
        else
        {
            if (agent.remainingDistance > lostDistance)
            {
                enamy = Enamy.Idle;
            }
        }

        //if (isChase)
        //{
        //    // 목표까지의 남은 거리가 멈추는 지점보다 작거나 같으면
        //    if (agent.remainingDistance <= agent.stoppingDistance)
        //    {
        //
        //    }
        //    // 목표와의 거리가 멀어진 경우
        //    else if (agent.remainingDistance > lostDistance)
        //    {
        //        target = null;
        //        agent.SetDestination(transform.position);
        //
        //        enamy = Enamy.Idle;
        //
        //    }
        //}
    }
    private void Update()
    {
        switch (enamy)
        {
            case Enamy.Idle:
                IdleStart();
                break;
            case Enamy.Chase:
                ChaseStart();
                break;
        }
        //if (isChase)
        //{
        //    if (target == null) return;
        //    {
        //        agent.SetDestination(target.position); // 도달할 목표지정
        //    }
        //}
    }
    //private void FixedUpdate()
    //{
    //    FreezeRotation();
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        //// Sphere Collider 가 Player 를 감지하면      
        target = other.transform;
        // NavMeshAgent의 목표를 Player 로 설정
        agent.SetDestination(target.position); // 도달할 목표지정
        // StateMachine을 추적으로 변경
        enamy = Enamy.Chase;
        // ChangeState(Enemy.Chase);
    }*/
/*    *//*IEnumerator OnDamage(Vector3 reactVac, bool isGround)
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if (curHealth > 0)
        {
            mat.color = Color.white;
        }
        else
        {
            mat.color= Color.gray;
            gameObject.layer = 14;
            isChase = false;
            agent.enabled = false;
            animator.SetTrigger("doDie");

            if (isGround)
            {
                reactVac = reactVac.normalized;
                reactVac += Vector3.up * 3;

                rigidbody.freezeRotation = false;
                rigidbody.AddForce(reactVac * 5, ForceMode.Impulse);
                rigidbody.AddTorque(reactVac * 15, ForceMode.Impulse);
            }
            else
            {
                reactVac = reactVac.normalized;
                reactVac += Vector3.up;
                rigidbody.AddForce(reactVac * 5, ForceMode.Impulse);
            }
            Destroy(gameObject, 4);
        }
    }*/

