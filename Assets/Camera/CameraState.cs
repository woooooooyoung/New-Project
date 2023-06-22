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
    [SerializeField] TPSClick tPSClick;
    [SerializeField] TPSCharacterController tpsCharacterController;
    [SerializeField] TPSMove tPSMove;

    [SerializeField] NavMeshAgent navMeshAgent;
    private Animator animator;

    //public Rigidbody rigidbody;
    //[SerializeField] PlayerInput fpsInputAciton;
    //[SerializeField] PlayerInput tvcInputAciton;
    //[SerializeField] Component fpsc;
    //[SerializeField] TopViewCamera tvcc;



    private Stats stats = Stats.FPS;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ChangeFPS();
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
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeTVC();
        }
    }
    private void TVCUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeFPS();
        }
    }

    private void ChangeFPS()
    {
        stats = Stats.FPS;
        Cursor.lockState = CursorLockMode.Locked;

        fps.SetActive(true);
        tvc.SetActive(false);

        tPSController.enabled = false;
        playerMove.enabled = true;
        navMeshAgent.enabled = false;
        tPSClick.enabled = false;
        tpsCharacterController.enabled = false;
        tPSMove.enabled = false;

        Debug.Log("FPS");
        fpsc.enabled = true;
        StopTPS();
    }

    private void ChangeTVC()
    {
        stats = Stats.TVC;
        Cursor.lockState = CursorLockMode.Confined;

        fps.SetActive(false);
        tvc.SetActive(true);

        tPSController.enabled = true;
        playerMove.enabled = false;
        navMeshAgent.enabled = true;
        tPSClick.enabled = true;
        tpsCharacterController.enabled = true;
        tPSMove.enabled = true;


        Debug.Log("TVC");
        fpsc.enabled = false;
        StopFPS();
    }
    private void StopFPS()
    {
        Debug.Log("FPS1");
        animator.SetFloat("XSpeed", 0f);
        animator.SetFloat("YSpeed", 0f);
        animator.SetFloat("FPSSpeed", 0f);
    }
    private void StopTPS()
    {
        Debug.Log("TPS1");
        animator.SetFloat("TPSSpeed", 0f);
    }

}
