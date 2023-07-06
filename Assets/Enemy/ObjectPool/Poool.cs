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
            // Poolable이 붙은 오브젝트를 부모의 transform으로 설정
        }
    }
    public Poolable GetPoool()
    {
        if (queuePool.Count > 0) // queuePool안의 배열 갯수가 0보다 크면
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

