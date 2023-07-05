using CrusaderUI.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SceneManagement;
using UnityEngine;
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
    public float p_CurrentMP;
    public float p_MaxMP;
    public float p_Attack;

    [Range(0f, 1f)]
    public float p_HPSlider;
    [Range(0f, 1f)]
    public float p_MPSlider;

    public HPController p_HPController;
    public MPController p_MPController;

    private void HealthPoint()
    {
        if (p_CurrentHP == 100f)
        {
            p_HPSlider = 1f;
        }
        else if (p_CurrentHP <= 90f)
        {
            p_HPSlider = 0.9f;
        }
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
        Silder();
        HitDamage();
        HealthPoint();
    }
    private void Silder()
    {
        p_HPController.h_Silder = p_HPSlider;
        p_MPController.m_Silder = p_MPSlider;
    }
    private void TakeDamage(int damage)
    {
        Debug.Log(damage);
        health -= damage;
    }
    private void HitDamage()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("½µ");
            Attack();
        }
    }
    private void Attack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                //enemy.TakeDamage(attackDamage);
            }
        }
    }

    private void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}


