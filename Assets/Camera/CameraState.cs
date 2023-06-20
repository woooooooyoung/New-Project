using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraState : MonoBehaviour
{
    public enum Stats {FPS, TVC}
    [SerializeField] GameObject fps;
    [SerializeField] GameObject tvc;

    [SerializeField] FPSCamera fpsc;
    [SerializeField] TVCPlayerController tPSController;
    [SerializeField] PlayerMove playerMove;

    [SerializeField] NavMeshAgent navMeshAgent;
    //public Rigidbody rigidbody;
    //[SerializeField] PlayerInput fpsInputAciton;
    //[SerializeField] PlayerInput tvcInputAciton;
    //[SerializeField] Component fpsc;
    //[SerializeField] TopViewCamera tvcc;



    private Stats stats = Stats.FPS;

    private void Awake()
    {

    }
    private void Update()
    {
        switch(stats)
        {
            case Stats.FPS:
                FPSUpdate();
                break;
            case Stats.TVC:
                TVCUpdate();
                break;
        }
    }

    private void FPSUpdate()
    {
        fps.SetActive(true);
        tvc.SetActive(false);

        tPSController.enabled = false;
        playerMove.enabled = true;
        navMeshAgent.enabled = false;

        //fpsInputAciton.enabled = true;

        Debug.Log("FPS");
        fpsc.enabled = true;


        //tvcc.enabled = false;
        if (Input.GetKeyDown(KeyCode.V))
        {
            stats = Stats.TVC;
        }
    }
    private void TVCUpdate()
    {
        fps.SetActive(false);
        tvc.SetActive(true);

        tPSController.enabled = true;
        playerMove.enabled = false;
        navMeshAgent.enabled = true;
        //fpsInputAciton.enabled = false;

        Debug.Log("TVC");
        //tvcc.enabled = true;
        fpsc.enabled = false;
        if (Input.GetKeyDown(KeyCode.V))
        {
            stats = Stats.FPS;
        }
    }
}
