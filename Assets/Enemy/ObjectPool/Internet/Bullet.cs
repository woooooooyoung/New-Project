using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour // Ǯ���� ���
{
    // pool ��� : �� ������ �� �ڵ�� pool�� ����Ѱ�
    Vector3 direction;
    [SerializeField] float speed;
    private IObjectPool<Bullet> managedPool; // pool ���
    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
    public void SetManagedPool(IObjectPool<Bullet> Pool) // pool ���
    {
        managedPool = Pool;
    }
    public void Shoot(Vector3 dir)
    {
        direction = dir;

        // 5�� �� �Ѿ� �ı�
        // Destroy(gameObject, 5f);
        Invoke("DestoryBullet", 5f); // pool ���
    }
    public void DestoryBullet() // pool ���
    {
        managedPool.Release(this);
    }
}
