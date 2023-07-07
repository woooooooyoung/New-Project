using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

namespace DesignPattern
{


    public class EnemySpnons
    {
        private Stack<PooledObject> objectPool = new Stack<PooledObject>();
        private int poolSize = 100;

        public void CreatePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                objectPool.Push(new PooledObject());
            }
        }

        public PooledObject GetPool()
        {
            if (objectPool.Count > 0)
            {
                return objectPool.Pop();
            }
            else
            {
                return new PooledObject();
            }
        }
        public void ReturnPool(PooledObject pooledObject)
        {
            objectPool.Push(pooledObject);
        }
    }

    public class PooledObject
    {

    }
}



    /*public GameObject enemy;
    public static MonsterSpawner instance;
    public Queue<GameObject> m_queue = new Queue<GameObject>();
    public float xPos;
    public float zPos;
    private Vector3 RandomVector;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        for (int i = 0; i < 10; i++)
        {
            GameObject t_object = Instantiate(enemy, this.gameObject.transform);
            m_queue.Enqueue(t_object);
            t_object.SetActive(false);
        }

        StartCoroutine(MonsterSpawn());
    }

    public void InsertQueue(GameObject p_object)
    {

        m_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject t_object = m_queue.Dequeue();
        t_object.SetActive(true);

        return t_object;
    }

    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            if (m_queue.Count != 0)
            {
                xPos = Random.Range(-5, 5);
                zPos = Random.Range(-5, 5);
                RandomVector = new Vector3(xPos, 0.0f, zPos);
                GameObject t_object = GetQueue();
                t_object.transform.position = gameObject.transform.position + RandomVector;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    public override void Die()
    {

        gameObject.SetActive(false);
        hpBar.SetActive(false);

        GetComponent<MonsterAttack>().enemies.Clear();
        GetComponent<MonsterState>().detected.Clear();

        MonsterSpawner.instance.InsertQueue(gameObject);
    }
    private void OnEnable() // 오브젝트 풀링에의해 다시 활성화될시 정보 초기화
    {
        if (hpBar != null)
        {
            hpBar.SetActive(true);
            HP = (int)MaxHp;
            hpSlider.value = 1.0f;
        }
    }*/


