using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaporn : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerEnter(Collider other)
    {
        IHittable hittable = other.GetComponent<IHittable>();
        hittable?.TakeHit(damage);
    }
}
