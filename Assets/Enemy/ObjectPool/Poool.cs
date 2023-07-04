using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Poool : MonoBehaviour
{
    public Poolable enemyPool;
    public int currentPool;
    public int maxPool;

    Queue<Poolable> queuePool = new Queue<Poolable>();

    private void Awake()
    {
        CreatePool();
    }
    private void CreatePool()
    {
        for (int i = 0; i < currentPool; i++)
        {
            Poolable pool = Instantiate(enemyPool);
            pool.gameObject.SetActive(false);
            pool.transform.SetParent(transform);
            queuePool.Enqueue(pool);
            // Poolable�� ���� ������Ʈ�� �θ��� transform���� ����
        }
    }
    public Poolable GetPoool()
    {
        if (queuePool.Count > 0) // queuePool���� �迭 ������ 0���� ũ��
        {
            Poolable pooled = queuePool.Dequeue();
            pooled.gameObject.SetActive(true);
            pooled.transform.parent = null;
            return pooled;
        }
        else
        {
            Poolable poolable = Instantiate(enemyPool);
            poolable.Poool = this;
            return poolable;
        }
    }
    public void Release(Poolable poolable)
    {
        if (queuePool.Count < maxPool)
        {
            poolable.gameObject.SetActive(false);
            poolable.transform.SetParent(transform);
            queuePool.Enqueue(poolable);
        }
        else
        { 
            Destroy(poolable);
        }
    }
}

