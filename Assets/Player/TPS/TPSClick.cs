using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class TPSClick : MonoBehaviour
{
    private Animator animator;
    [SerializeField]private NavMeshAgent navMeshAgent;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("2");
        }
    }

    private void Update()
    {
        OnMouseDown();
        StopAgent();
    }
    private void StopAgent()
    {
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    navMeshAgent.enabled = false;
        //
        //}
        //else if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    navMeshAgent.enabled = true;
        //}
    }
    /*private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ���� ��ư�� Ŭ���� ���� ������ �����մϴ�.
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                // Ŭ���� ��ġ�� ���� ó���� �����մϴ�.
                // hit.collider�� ���� Ŭ���� ������Ʈ�� ������ ���� �� �ֽ��ϴ�.
                // ���� ���, Ŭ���� ��ġ�� �ִ� ������ �����ϰų� �̵��� �� �ֽ��ϴ�.
            }
        }
    }*/
    /*    private void OnMouseDown()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
            }
        }*/

    /*    private bool mouseState;
        private GameObject target;
        private Vector3 MousePos;
        private Camera mainCam = null;

        private void Start()
        {
            mainCam = Camera.main;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = GetClickedObject();

                if (target.Equals(gameObject))
                {
                    mouseState = true;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                mouseState = false;
            }
            if (mouseState)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                transform.localScale = new Vector3(1f,1f,1f);
            }
        }
        private GameObject GetClickedObject()
        {
            RaycastHit hit;
            GameObject target = null;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if ( Physics.Raycast(ray.origin, ray.direction * 10, out hit) )
            {
                target = hit.collider.gameObject;
            }
            return target;
        }*/
    /* [SerializeField] float moveSpeed;
     [SerializeField] float zoomScroll;
     Vector3 moveDir;

     private void LateUpdate()
     {
         Zoom();
         Move();
     }
     private void Move()
     {
         transform.Translate(Vector3.forward * moveDir.y * moveSpeed * Time.deltaTime, Space.World);
         transform.Translate(Vector3.right * moveDir.y * moveSpeed * Time.deltaTime, Space.World);
     }

     private void OnPointer(InputValue value)
     {
         moveDir = value.Get<Vector2>();
         Debug.Log(moveDir);
     }
     private void Zoom()
     {
         transform.Translate(Vector3.forward * zoomScroll * Time.deltaTime, Space.Self);
     }
     private void OnZoon(InputValue value)
     {
         zoomScroll = value.Get<Vector2>().y;
         Debug.Log(zoomScroll);
     }*/
}
