using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    [SerializeField] float relaseTime;

    private ObjectPool pool;

    public ObjectPool Pool { get { return pool; } set {  pool = value; } }

    private void Start()
    {
        StartCoroutine(ReleaseTimer());
    }
    IEnumerator ReleaseTimer()
    {
        yield return new WaitForSeconds(relaseTime);
    }
}
