using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class CameraState : MonoBehaviour
{
    public enum Stats {FPS, TVC}
    [SerializeField] GameObject fps;
    [SerializeField] GameObject tvc;
    //[SerializeField] PlayerInput fpsInputAciton;
    //[SerializeField] PlayerInput tvcInputAciton;
    //[SerializeField] Component fpsc;
    [SerializeField] FPSCamera fpsc;
    //[SerializeField] TopViewCamera tvcc;
    [SerializeField] TVCPlayerController tvcc;



    private Stats stats = Stats.FPS;

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

        tvcc.enabled = false;

        //fpsInputAciton.enabled = true;

        Debug.Log("FPS");
        fpsc.enabled = true;
        
        //tvcc.enabled = false;
        if (Input.GetKeyDown(KeyCode.V))
        {
            //if (stats == Stats.FPS)
            //{
            stats = Stats.TVC;
            //}
        }
    }
    private void TVCUpdate()
    {
        fps.SetActive(false);
        tvc.SetActive(true);

        tvcc.enabled = true;
        //fpsInputAciton.enabled = false;

        Debug.Log("TVC");
        //tvcc.enabled = true;
        fpsc.enabled = false;
        if (Input.GetKeyDown(KeyCode.V))
        {
            //if (stats == Stats.TVC) 
            //{
            stats = Stats.FPS;
            //}
        }
    }
}
