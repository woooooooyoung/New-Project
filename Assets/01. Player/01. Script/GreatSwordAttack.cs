using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GreatSwordAttack : MonoBehaviour
{
    [SerializeField] GameObject p_GreatSword;
    private Animator a_GreatSword;
    
    private void Awake()
    {
        a_GreatSword = GetComponent<Animator>();
    }
    private void Update()
    {
        if (p_GreatSword.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                a_GreatSword.SetTrigger("p_Attack");
            }
        }
    }
    //public void Attack()
    //{
    //    if (p_GreatSword.activeSelf)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            a_GreatSword.SetTrigger("p_Attack");
    //        }
    //    }
    //}
    //private void OnAttack(InputValue value)
    //{
    //    Attack();
    //}
    public void StartAttack()
    {
        Debug.Log("Ω√¿€");
    }
    public void EndAttack()
    {
        Debug.Log("≥°");
    }
}
