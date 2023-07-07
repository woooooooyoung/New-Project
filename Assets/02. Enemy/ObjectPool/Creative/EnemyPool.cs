using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    private EnemyInformation enemyInformation;
    private IObjectPool<EnemyPool> pool;
    public void SetManagedPool(IObjectPool<EnemyPool> Pool)
    {
        pool = Pool;
    }
    public void Release()
    {
        if (enemyInformation.currentHp <= 0)
        {
            pool.Release(this);
        }
           
    }
}
