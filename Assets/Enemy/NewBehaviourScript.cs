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
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer1;

    //public Transform currentStart;
    //public GameObject attackPoinrt;
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
        gameObject.SetActive(true);
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
        //agent.SetDestination(target.position);
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        if (target == null)
        {
            enemyState = EnemyState.Idle;
        }
        //if ()
        //{
        //
        //}
        //{
        //    //animator.SetBool("isAttack", true);
        //    animator.SetTrigger("isAttack1");
        //    enemyState = EnemyState.Attack;
        //}
        //if (lostDistance < attackRang)
        //{
        //    enemyState = EnemyState.Attack;
        //}
        if (agent.remainingDistance > lostDistance) 
        {
            target = null;
            enemyState = EnemyState.Idle;
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
        //animator.SetBool("isAttack", true);
        animator.SetBool("isWalk", false);
        if (target == null)
        {
            enemyState = EnemyState.Idle;
        }
        if (agent.remainingDistance > attackRang)
        {
            enemyState = EnemyState.Chase;
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
        if ( currentHp == maxHp)
        {
            animator.Play("Sword And Shield Idle");
            enemyState = EnemyState.Idle;
        }
    }
    private void SkinON()
    {
        skinnedMeshRenderer.enabled = true;
        skinnedMeshRenderer1.enabled = true;
    }
    private void SkinOFF()
    {
        skinnedMeshRenderer.enabled = false;
        skinnedMeshRenderer1.enabled = false;
    }
    private void MaxHP()
    {
        currentHp = maxHp;
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
