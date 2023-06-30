using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public bool deBug;


    public float lostDistance;

    public float attackRang;

    public float eyes;
    public int maxHp;
    public int currentHp;

    public bool onDie;

    public Transform target;
    public Transform currentStart;
    public GameObject attackPoinrt;
    private float ySpeed = 0;
    private float jumpSpeed;
    NavMeshAgent agent;
    Animator animator;
    CharacterController characterController;
    Vector3 moveDir;
    
    
    private enum EnemyState { Idle, Chase, Attack, Die }
    EnemyState enemyState = EnemyState.Idle;
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        currentHp = maxHp;
        //currentStart = transform;
        //animator.ResetTrigger("doDie");
    }
    private void Update()
    {
        
        switch (enemyState)
        {
            case EnemyState.Idle: // 가만히 있다
                Idle();
                break;
            case EnemyState.Chase:  // 추격
                Chase();
                break;
            case EnemyState.Attack: // 공격
                Attack(); 
                break;
            case EnemyState.Die:    // 죽음
                Die(); 
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            print("ㄱㄱ");
            target = other.transform;
            agent.SetDestination(target.position);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.name == "Player")
        {
            print("ㅌㅌ");
            target = null;
            
        }
    }
    private void Idle()
    {
        Debug.Log("Idle");
        animator.SetBool("isWalk", false);
        animator.SetBool("isAttack", false);
        
        if (target != null)
        {
            enemyState = EnemyState.Chase;
        }
        if (currentHp <= 0)
        {
            animator.SetTrigger("doDie");
            enemyState = EnemyState.Die;
        }

    }
    private void Chase()
    {
        Debug.Log("Chase");
        animator.SetBool("isWalk", true);
        animator.SetBool("isAttack", false);
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        else if (target == null)
        {
            enemyState = EnemyState.Idle;
        }
        if (agent.remainingDistance <= attackRang)
        {
            enemyState = EnemyState.Attack;
        }
        if (currentHp <= 0)
        {
            animator.SetTrigger("doDie");
            enemyState = EnemyState.Die;
        }

    }
    private void Attack()
    {
        Debug.Log("Attack");
        animator.SetBool("isAttack", true);
        animator.SetBool("isWalk", false);
        if (target == null)
        {
            enemyState= EnemyState.Idle;
        }
        if (currentHp <= 0)
        {
            animator.SetTrigger("doDie");
            enemyState = EnemyState.Die;
        }
    }
    private void Die()
    {
        Debug.Log("die");
        //Invoke("MaxHP", 9);
        //Invoke("ObjOFF", 8);
        //Invoke("ObjON", 10);
        if ( currentHp == maxHp)
        {
            //animator.ResetTrigger("doDie");
            enemyState = EnemyState.Idle;
        }
    }
    private void MaxHP()
    {
        currentHp = maxHp;
    }
    private void ObjOFF()
    {
        gameObject.SetActive(false);
    }
    private void ObjON()
    {
        gameObject.SetActive(true);
    }


    private void OnDrawGizmosSelected()
    {
        if (!deBug)
            return;


        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lostDistance);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRang);
    }
}
