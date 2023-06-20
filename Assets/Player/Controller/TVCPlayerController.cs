using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;


public class TVCPlayerController : MonoBehaviour
{
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("��Ŭ�� ����");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("��Ŭ�� ����");
        }
        else if(Input.GetMouseButtonDown(2))
        {
            Debug.Log("�ٹ�ư ����");
        }
    }
}
