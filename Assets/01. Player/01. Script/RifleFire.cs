using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RifleFire : MonoBehaviour
{
    [SerializeField] GameObject p_Rifle;
    public Animator a_Riflie;
    public bool SemiAutomatic = true;
    public bool TripleBurst = true;
    public bool AutomaticFire = true;

    public enum ChangingFiringMode { SemiAutomatic, TripleBurst, AutomaticFire }
    ChangingFiringMode changingFiringMode = ChangingFiringMode.AutomaticFire;
    private void Awake()
    {
        a_Riflie = GetComponent<Animator>();
    }
    private void Update()
    {
        switch (changingFiringMode)
        {
            case ChangingFiringMode.AutomaticFire:
                Automatic_Fire();
                break;
            case ChangingFiringMode.TripleBurst:
                Triple_Burst();
                break;
            case ChangingFiringMode.SemiAutomatic:
                Semi_Automatic();
                break;


        }
    }
    private void Automatic_Fire()
    {
        if (Input.GetMouseButton(0))
        {

        }
        if (p_Rifle.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                changingFiringMode = ChangingFiringMode.SemiAutomatic;
            }
        }
    }
    private void Semi_Automatic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            changingFiringMode = ChangingFiringMode.TripleBurst;
        }
        if (p_Rifle.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {

            }
        }
    }
    private void Triple_Burst()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
        if (p_Rifle.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                changingFiringMode = ChangingFiringMode.AutomaticFire;
            }
        }
    }

    private void ChangingFiringMode1()
    {
        if (SemiAutomatic)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (SemiAutomatic)
                {
                    Semi_Automatic();
                    TripleBurst = false;
                    AutomaticFire = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {

        }
        if (Input.GetKeyDown(KeyCode.B))
        {

        }
    }

}
