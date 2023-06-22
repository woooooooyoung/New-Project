using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;


public class TVCPlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    private bool isMove;
    private Vector3 destination;
    private Animator animator;


    private void Start()
    {
        animator.StopPlayback();
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        destination = Vector3.zero;
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
                animator.SetFloat("TPSSpeed", 2.0f);
            }
        }
        if (agent.remainingDistance < 0.1f)
        {
            animator.SetFloat("TPSSpeed", 0f);
        }
        if (Input.GetKey(KeyCode.LeftShift))        // LeftShift 누르고있는 상태
        {
            Debug.Log("ls");
            agent.ResetPath();                      // 네비메쉬에이전트 멈추기
            animator.SetFloat("TPSSpeed", 0f);
        }
    }

}
