using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour

{
    [SerializeField] Poolable poolablePrefab;

    [SerializeField] int poolSize; // 한번에 생성되는 갯수
    [SerializeField] int maxSize;  // 객체에 담을수 있는 최대 Pool의 갯수

    private Stack<Poolable> stackPool = new Stack<Poolable>();   // Push, Pop
    //private Queue<Poolable> stackPool = new Queue<Poolable>(); // Enqueue, Dequeue
    //private List<Poolable> stackPool = new List<Poolable>();   // Add, Remove(n)

    private void Awake()
    { 
        CreatePool();
    }
    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Poolable poolable = Instantiate(poolablePrefab);
            poolable.gameObject.SetActive(false);
            poolable.transform.SetParent(transform);
            poolable.Pool = this;
            stackPool.Push(poolable);
            //stackPool.Enqueue(poolable);
            //stackPool.Add(poolable);
        }
    }
    public Poolable Get()
    {
        if (stackPool.Count > 0)
        {
            Poolable poolable = stackPool.Pop();
            //Poolable poolable = stackPool.Dequeue();
            //Poolable poolable = stackPool.Remove();
            poolable.gameObject.SetActive(true);
            poolable.transform.parent = null;
            return poolable;
        }
        else
        {
            Poolable poolable = Instantiate(poolablePrefab);
            poolable.Pool = this;
            return poolable;
        }
    }
    public void Release(Poolable poolable)
    {
        if (stackPool.Count < maxSize)
        {
            poolable.gameObject.SetActive(false);
            poolable.transform.SetParent(transform);
            stackPool.Push(poolable);
            //stackPool.Enqueue(poolable);
            //stackPool.Add(poolable);
        }
        else
        {
            //Destroy(poolable); // O
            Destroy(poolable.gameObject);
        }
    }
}
