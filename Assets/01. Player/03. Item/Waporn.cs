using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waporn : MonoBehaviour
{
    [SerializeField] int damage;

    public Collider coll;

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
        if (other.name == "Player")
        {
            Debug.Log("�ƾƾƾƾ�");
            IHittable hittable = other.GetComponent<IHittable>();
            hittable?.TakeHit(damage);
            DisableWeapon();
        }
    }
}
