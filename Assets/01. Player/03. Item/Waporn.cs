using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waporn : MonoBehaviour
{
    [SerializeField] int damage;

    Collider coll;

    private void Awake()
    {
        coll = GetComponent<Collider>();
    }

    public void EnableWeapon()
    {
        coll.enabled = true;
    }

    public void DisableWeapon()
    {
        coll.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("아아아아아");
            IHittable hittable = other.GetComponent<IHittable>();
            hittable?.TakeHit(damage);
        }
    }
}
