using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    private ObjectPool pool;
    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Poolable poolable = pool.Get();
            poolable.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        }
    }
}
