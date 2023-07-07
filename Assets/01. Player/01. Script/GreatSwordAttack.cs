using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GreatSwordAttack : MonoBehaviour
{
    

    [SerializeField] GameObject p_GreatSword;
    public bool isAttack;
    private Animator a_GreatSword;
    public enum Attacks { Attack, StopAttack }
    private Attacks attack = Attacks.StopAttack;
    private void Awake()
    {
        a_GreatSword = GetComponent<Animator>();
    }
    private void Update()
    {
        switch (attack)
        {
            case Attacks.Attack:
                Attack();
                break;
            case Attacks.StopAttack:
                StopAttack();
                break;

        }
    }

    private void Attack()
    {
        if (p_GreatSword.activeSelf)
        {
            if(Input.GetMouseButtonDown(0))
            {
                a_GreatSword.SetBool("p_Attack", true);
                attack = Attacks.StopAttack;
            }
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            if (!isAttack)
            {
                a_GreatSword.SetBool("p_Attack", true);

                if (Input.GetMouseButton(0))
                {
                    isAttack = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            a_GreatSword.SetBool("p_Attack", false);
            Debug.Log("¾È½´½µ");
            isAttack = false;
        }*/
    }
    private void StopAttack()
    {
        if()
    }
}
