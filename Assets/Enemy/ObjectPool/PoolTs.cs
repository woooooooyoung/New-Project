using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTs : MonoBehaviour
{
    public bool isStop;
    private Poool objectPool;
    private Poolable poolable;
    private EnemyInformation enemy;
    public float time;
    public float setTime;
    public int setPool;
    public int maxPool;
    public int currentPool;
    private void Awake()
    {
        objectPool = GetComponent<Poool>();
        //Test0();
    }
    private void Start()
    {
        //Test0();
    }
    void Update()
    {
        time += Time.deltaTime;
        Test0();
        if (isStop)
        {
            time = 0;
        }
    }
    private void Test0()
    {
        if (time > setTime)
        {

            if (currentPool < maxPool)
            {
                for (int i = 0; i < setPool; i++)
                {
                    Poolable poolable = objectPool.GetPoool();
                    poolable.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
                    time = 0;
                    currentPool++;
                }
           }
           else if (currentPool > maxPool)
           {
                Destroy(poolable.gameObject);
               return;
           }

        }
    }
}
