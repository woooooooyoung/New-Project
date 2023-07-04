using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private Camera mainCam;


    private IObjectPool<Bullet> pool; // Pool 사용
    private void Awake()
    {
        // 밑에 만든 함수들을 Pool의 생성자 매개변수에 넣어주고, 생성 가능한 오브젝트 최대갯수도 넣어줌 (maxSize: n)
        pool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, maxSize: 200); // Pool 사용
    }
    private void Start()
    {
        mainCam = Camera.main;

    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                    var direction = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                // 총알을 새로 생성해서 사용
                //var bullet =Instantiate(bulletPrefab, transform.position + direction.normalized, Quaternion.identity).GetComponent<Bullet>();
                var bullet = pool.Get(); // 총알을 프리팹화 해서 총알 오브젝트를 생성하는 부분의 코드를 오브젝트 풀을 사용하도록 코드를 수정
                bullet.transform.position = transform.position + direction.normalized;
                bullet.Shoot(direction.normalized);
            }
        }
    }
    private Bullet CreateBullet() // Bullet 생성시 호출 함수
    {
        Bullet bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();   // 가지고 있는 프리팹으로 Bullet 생성
        bullet.SetManagedPool(pool);                                        // 생성된 Bullet오브젝트에 자신이 등록되어야 할 Pool
        return bullet;                                                      // 반환
    }
    private void OnGetBullet(Bullet bullet)                                 // 오브젝트를 Pool에 빌려올 때 사용될 함수
    {
        bullet.gameObject.SetActive(true);
    }
    private void OnReleaseBullet(Bullet bullet)                             // 오브젝트를 Pool에 돌려줄 때 사용될 함수
    {
        bullet.gameObject.SetActive(false);
    }
    private void OnDestroyBullet(Bullet bullet)                             // 오브젝트를 Pool에서 파괴될 때 사용될 함수
    {
        Destroy(bullet.gameObject);
    }
}
