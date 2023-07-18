using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class Bow : MonoBehaviour
{

    public float ground;

    private Animator m_Animator;
    private CharacterController m_CharacterController;
    private NavMeshAgent m_NavMeshAgent;
    private bool deBug;

    private enum EnemyState { Idle, Chase, Attack, Die }
    private EnemyState m_EnemyState;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_CharacterController = GetComponent<CharacterController>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Player")
        {

        }
    }
    private void EyesFind()
    {

    }
    private void Ground()
    {
        if (!m_CharacterController.isGrounded)
        {
            // 땅 체크
            if (Physics.Raycast(transform.position, Vector3.down, ground))
            {
                m_CharacterController.Move(Vector3.down * ground); // 아래로 이동
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (!deBug)
            return;


        //Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(transform.position, lostDistance);
        //
        //Gizmos.color = Color.white;
        //Gizmos.DrawWireSphere(transform.position, attackRang);
    }
}

