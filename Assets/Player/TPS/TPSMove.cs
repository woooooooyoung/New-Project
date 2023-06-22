using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TPSMove : MonoBehaviour
{
    [SerializeField] float dashSpeed;
    private Vector3 moveDir;
    private Rigidbody rigidbody;

    private void Awake()
    {

    }
    private void OnEnable()
    {
        gameObject.AddComponent<Rigidbody>();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void OnDisable()
    {
        Destroy(GetComponent<Rigidbody>());
    }
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("½µ ½´½µ");
            
            
        }

    }
}
