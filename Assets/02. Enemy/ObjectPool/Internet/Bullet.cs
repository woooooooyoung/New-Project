using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour // 풀링의 대상
{
    // pool 사용 : 이 문장이 들어간 코드는 pool을 사용한것
    Vector3 direction;
    [SerializeField] float speed;
    private IObjectPool<Bullet> managedPool; // pool 사용
    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
    public void SetManagedPool(IObjectPool<Bullet> Pool) // pool 사용
    {
        managedPool = Pool;
    }
    public void Shoot(Vector3 dir)
    {
        direction = dir;

        // 5초 후 총알 파괴
        // Destroy(gameObject, 5f);
        Invoke("DestoryBullet", 5f); // pool 사용
    }
    public void DestoryBullet() // pool 사용
    {
        managedPool.Release(this);
    }
}
