using CrusaderUI.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour
{

    [Header("Information")]
    public string name;
    public int health;
    public float moveSpeed;
    public int attackDamage;

    public float p_CurrentHP;
    public float p_MaxHP;
    //public float p_AddHP;
    public float p_CurrentMP;
    public float p_MaxMP;
    //public float p_AddMP;
    public float p_Attack;

    [Range(0f, 1f)]
    public float p_HPSlider;
    [Range(0f, 1f)]
    public float p_MPSlider;

    public HPController p_HPController;
    public MPController p_MPController;

    private void HealthPoint()
    {
        p_HPController.h_Silder = p_HPSlider;
        float p_HP = p_CurrentHP / p_MaxHP;
        p_HPSlider = p_HP;
    }
    private void ManaPoint()
    {
        p_MPController.m_Silder = p_MPSlider;
        float p_MP = p_CurrentMP / p_MaxMP;
        p_MPSlider = p_MP;
    }

    private void Awake()
    {
        p_HPSlider = 1f;
        p_MPSlider = 1f;

        //p_HPController = GetComponent<HPController>();
        //p_MPController = GetComponent<MPController>();
        //p_HPController = gameObject.GetComponent<HPFlowController>();
        //p_HPController = GetComponent<HPFlowController>();
        //p_MPController = GetComponent<MPFlowController>();
    }
    void Start()
    {
        p_CurrentHP = p_MaxHP;
        p_CurrentMP = p_MaxMP;
    }
    // Update is called once per frame
    void Update()
    {
        //HitDamage();
        HealthPoint();
        ManaPoint();
    }
    /*private void Silder()
    {
        p_HPController.h_Silder = p_HPSlider;
        p_MPController.m_Silder = p_MPSlider;
    }*/
    private void TakeHit(int damage)
    {
        Debug.Log(damage);
        p_CurrentHP -= damage;
    }
    //private void HitDamage()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Debug.Log("½µ");
    //        Attack();
    //    }
    //}
    //private void Attack()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        Enemy enemy = hit.collider.GetComponent<Enemy>();
    //        if (enemy != null)
    //        {
    //            //enemy.TakeDamage(attackDamage);
    //        }
    //    }
    //}

    private void Die()
    {
        if (p_CurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}