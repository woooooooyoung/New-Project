using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Weapon Information")]
    [SerializeField] string waponName;      //이름
    [SerializeField] int bulletsPerMag;     // 탄창 당 장탄 수
    [SerializeField] int bulletsTotal;      // 전체 가지고 있는 총알 수
    [SerializeField] int currentBullets;    // 현재 탄창에 남아있는 총탄 수
    [SerializeField] float range;           // 사정거리
    [SerializeField] float fireRate;        // 연사속도
    [SerializeField] float damage;          // 데미지

    [SerializeField] float fireTimer;       // 총탄과 총탄 사이의 발사 간격 설정

    [SerializeField] Transform shootPoint;  // 총탄이 실제 발사되는 지점

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
