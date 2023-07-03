using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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
    public bool onAttack;
    public bool offAttack;

    public Transform target;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer1;

    //public Transform currentStart;
    //public GameObject attackPoinrt;
    private float ySpeed = 0;
    private float jumpSpeed;
    public float ground;
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
        characterController = GetComponent<CharacterController>();
        currentHp = maxHp;
    }
    private void Update()
    {
        Ground();
        switch (enemyState)
        {
            case EnemyState.Idle: // ������ �ִ�
                Idle();
                break;
            case EnemyState.Chase:  // �߰�
                Chase();
                break;
            case EnemyState.Attack: // ����
                Attack(); 
                break;
            case EnemyState.Die:    // ����
                Die(); 
                break;
        }
    }
    /**********************************************************************
     * <�ѹ��� �浹�� �ʿ��ҋ� ����>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" )
        {
            print("����");
            target = other.transform;
            agent.SetDestination(target.position);
    
            float ToPlayer = Vector3.Distance(transform.position, other.transform.position);
            
            if (ToPlayer <= attackRang)
            {
                animator.SetTrigger("isAttack1");
                Debug.Log("����");
                enemyState = EnemyState.Attack;
            }
        }
        
    }
    **********************************************************************/
    
    public void OnTriggerStay(Collider other)
    {

        if (other.name == "Player")
        {
            if (currentHp > 0)
            {
                target = other.transform;
                agent.SetDestination(target.position);
                float ToPlayer = Vector3.Distance(transform.position, other.transform.position);
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                if ( target == null)
                {
                    enemyState = EnemyState.Idle;
                }
                else if (target == null && ToPlayer <= attackRang) // Ÿ���� null�̰� �÷��̾ attack���� �Ÿ��� ���ų� ���� ��
                {
                    enemyState = EnemyState.Idle;
                }
                else if (target != null && ToPlayer <= attackRang) // Ÿ���� null�� �ƴϰų� �÷��̰� attack���� �Ÿ��� ���ų� ���� ��
                {
                    Debug.Log("����");
                    enemyState = EnemyState.Attack;
                }
                else if (target != null && ToPlayer > attackRang) // Ÿ���� null�� �ƴϰų� �÷��̰� attack���� �Ÿ����� Ŭ ��
                {
                    if (stateInfo.IsName("Sword And Shield Slash (1)") && stateInfo.normalizedTime > 1f) // ���� �� �Ȳ���� �ϱ� ���� ����
                    {                                   
                        Debug.Log("������ ���");
                        enemyState = EnemyState.Chase;
                    }
                }
            }
            else
            {
                enemyState = EnemyState.Die;
            }
        }
    }




    private void Ground()
    {
        if (!characterController.isGrounded)
        {
            // �� üũ
            if (Physics.Raycast(transform.position, Vector3.down, ground))
            {
                characterController.Move(Vector3.down * ground); // �Ʒ��� �̵�
            }
        }
    }
    private void Idle()
    {
        SkinON();
        Debug.Log("Idle");

        animator.SetBool("isWalk", false);
        animator.SetBool("isAttack", false);
        animator.SetBool("isDie", false);
        
        if (target != null)
        {
            enemyState = EnemyState.Chase;
        }
        if (currentHp == 0)
        {
            enemyState = EnemyState.Die;
        }
    }
    private void Chase()
    {
        SkinON();
        Debug.Log("Chase");

        animator.SetBool("isWalk", true);
        animator.SetBool("isAttack", false);
        animator.SetBool("isDie", false);

        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        if (target == null)
        {
            enemyState = EnemyState.Idle;
        }
        if (agent.remainingDistance > lostDistance)
        {
            target = null;
            enemyState = EnemyState.Idle;
        }
        if (currentHp == 0)
        {
            enemyState = EnemyState.Die;
        }
    }
    private void Attack()
    {
        SkinON();
        Debug.Log("Attack");

        animator.SetBool("isAttack", true);
        animator.SetBool("isDie", false);
        

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // �ִϸ��̼� ���� üũ

        if (target == null)
        {
            enemyState = EnemyState.Idle;
        }
        if (currentHp == 0)
        {
            enemyState = EnemyState.Die;
            
        }
        if (stateInfo.IsName("Sword And Shield Slash (1)") && stateInfo.normalizedTime > 1f) // Sword And Shield Slash (1) �ִϸ��̼��� 1���� ũ�� ����
        {
            animator.SetBool("isAttack", false);
            Debug.Log("��");
            if (agent.remainingDistance > attackRang)
            {
               enemyState = EnemyState.Chase;
            }
            if (currentHp == 0)
            {
                enemyState = EnemyState.Die;
            }
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Sword And Shield Slash (1)"))
        {
            Debug.Log("���ݻ��°� �ƴϹǷ� ����");
            animator.Play("Sword And Shield Slash (1)");
        }

    }
    private void Die()
    {
        Debug.Log("die");
        animator.SetBool("isDie", true);

        if (currentHp == maxHp)
        {
            animator.SetBool("isDie", false);
        }

        //AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //if (stateInfo.IsName("Sword And Shield Death") && stateInfo.normalizedTime > 1f)
        //{
        //    Debug.Log("die");
        //
        //}
        //if (currentHp == maxHp)
        //{
        //    animator.Play("Sword And Shield Idle");
        //    enemyState = EnemyState.Idle;
        //}

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
