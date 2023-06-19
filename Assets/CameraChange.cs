using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraChange: MonoBehaviour
{
    private FPSCamera fps;
    private TopViewCamera top;
    public GameObject camera;

    private void Awake()
    {
        fps = GetComponent<FPSCamera>();
        top = GetComponent<TopViewCamera>();
    }
    private void Start()
    {
        top = GetComponent<TopViewCamera>();
    }
    private void Change(InputValue value)
    {
        if(fps)
        {
            GetComponent<TopViewCamera>();
        }
        else if (top)
        {
            GetComponent<FPSCamera>();
            
        }
    }
}
