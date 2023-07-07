using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private EnemyInformation enemyInformation;

    private IObjectPool<EnemyPool> pool;
    private void Awake()
    {
        pool = new ObjectPool<EnemyPool>(CreateEnemy, GetEnemy, DieRelease, maxSize: 1);
    }
    private void Update()
    {
        pool.Get();
    }
    private EnemyPool CreateEnemy()
    {
        EnemyPool enemyPool = Instantiate(enemyPrefab).GetComponent<EnemyPool>();
        enemyPool.SetManagedPool(pool);
        return enemyPool;
    }
    public void GetEnemy(EnemyPool enemyPool)
    {
        enemyPool.gameObject.SetActive(true);
    }
    public void DieRelease(EnemyPool enemyPool)
    {
        enemyPool.gameObject.SetActive(false);
    }
}
