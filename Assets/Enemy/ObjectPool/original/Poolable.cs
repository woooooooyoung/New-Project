using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Poolable : MonoBehaviour
{
    [SerializeField] float relaseTime;
    private EnemyInformation enemy;
    public float time;
    
    private ObjectPool pool;
    private Poool poool;
    
    public ObjectPool Pool { get { return pool; } set { pool = value; } }
    public Poool Poool { get { return poool; } set { poool = value; } }
    private void Update()
    {
        time += Time.deltaTime;
    }
    
    private void Start()
    {
        StartCoroutine(ReleaseTimer()); 
    }
    IEnumerator ReleaseTimer()
    {
        yield return new WaitForSeconds(relaseTime);
        //pool.Release(this);
        poool.Release(this);
    }
}
