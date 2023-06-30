using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool deBug;
    public Transform target;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.name == "Player")
        {

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        if (!deBug)
            return;


        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lostDistance);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRang);
    }
}
