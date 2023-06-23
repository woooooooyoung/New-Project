using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    [Header("Information")]
    public string name;
    public int health;
    public float moveSpeed;
    public int attackDamage;
    void Start()
    {
        gameObject.name = name;
    }
    // Update is called once per frame
    void Update()
    {
        HitDamage();
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
                enemy.TakeDamage(attackDamage);
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


