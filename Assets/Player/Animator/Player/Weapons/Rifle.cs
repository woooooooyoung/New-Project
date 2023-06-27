using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Weapon Information")]
    [SerializeField] string waponName;      //�̸�
    [SerializeField] int bulletsPerMag;     // źâ �� ��ź ��
    [SerializeField] int bulletsTotal;      // ��ü ������ �ִ� �Ѿ� ��
    [SerializeField] int currentBullets;    // ���� źâ�� �����ִ� ��ź ��
    [SerializeField] float range;           // �����Ÿ�
    [SerializeField] float fireRate;        // ����ӵ�
    [SerializeField] float damage;          // ������

    [SerializeField] float fireTimer;       // ��ź�� ��ź ������ �߻� ���� ����

    [SerializeField] Transform shootPoint;  // ��ź�� ���� �߻�Ǵ� ����

    private Animator animator;

    private enum RifleState { FPSRifle, TPSRifle }
    RifleState rifleState = RifleState.FPSRifle;

    private void Start()
    {
        currentBullets = bulletsPerMag;
        //FPSRifle();
    }
    private void Update()
    {
        
        if(Input.GetMouseButton(0))
        {
            if (currentBullets > 0)
            {
                Fire();
            }
            if (fireTimer < fireRate)
            {
                fireTimer += Time.deltaTime;
            }
        }
    }
    private void Fire()
    {
        if (fireTimer < fireRate)
        {
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.LogWarning(hit.transform.name);
        }
        currentBullets--;
        fireTimer = 0.0f;
        //switch (rifleState)
        //{
        //    case RifleState.FPSRifle:
        //        FPSRifle();
        //        break;
        //    case RifleState.TPSRifle:
        //        TPSRifle();
        //        break;
        //}
    }

    //private void FPSRifle()
    //{
    //    if(Input.GetKeyDown(KeyCode.V))
    //    {
    //        rifleState = RifleState.FPSRifle;
    //    }
    //}
    //private void FPSRifleFire()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        animator.Play("FPSRifleFireStop");
    //    }
    //    //else if ()
    //    //{ 
    //    //}
    //}
    //private void TPSRifle()
    //{
    //
    //    if (Input.GetKeyDown(KeyCode.V))
    //    {
    //        rifleState = RifleState.TPSRifle;
    //    }
    //}
}   
