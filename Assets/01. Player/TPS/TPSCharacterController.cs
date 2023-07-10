using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{

    [SerializeField] Camera camera;

    private bool isMove;
    private Vector3 destination;
    private void Awake()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (isMove)
        {
            if (Vector3.Distance(destination, transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }
            var dir = destination - transform.position;
            transform.forward = dir; 
            transform.position += dir.normalized * Time.deltaTime * 5f;
        }
    }
}
