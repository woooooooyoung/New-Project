using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Information")]
    public string name;
    public float health;
    public float moveSpeed;
    public float attackDamage;
    private void Start()
    {
        gameObject.name = name;

    }
    private void Update()
    {
        // 플레이어 따라가기
    }
    public void TakeDamage(int damage)
    {
        Debug.Log(health);
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }



}
