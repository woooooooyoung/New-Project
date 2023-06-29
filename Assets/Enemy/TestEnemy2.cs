using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TestEnemy2 : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public float lostDistance;
    public Transform target;
    public bool isChase;

    Material mat;
    Animator animator;
    NavMeshAgent agent;
    CharacterController characterController;
    Rigidbody rigidbody;

    private EnemyState currentState;

    public enum EnemyState { Idle, Chase, Attack, Die }

    private void Start()
    {
        // 초기상태
        currentState = EnemyState.Idle;
        // 시작
        StartCoroutine(StateMachine());
    }
    private IEnumerator StateMachine()
    { yield break; }
    private IEnumerable Idle()
    { yield break; }
    private IEnumerable Chase()
    { yield break; }
    private IEnumerable Attack()
    { yield break; }
    private IEnumerable Die()
    { yield break; }































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
    *//*IEnumerator OnDamage(Vector3 reactVac, bool isGround)
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
}
