using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMonsterSpawn : MonoBehaviour
{
    // 몬스터 스포너 돚거
    public GameObject monster;
    public static Poolable instance;
    public Queue<GameObject> m_queue = new Queue<GameObject>();
    public float xPos;
    public float zPos;
    private Vector3 RandomVector;
    private EnemyInformation enm;

    // Start is called before the first frame update
    void Start()
    {
        //instance = this;

        for (int i = 0; i < 10; i++)
        {
            GameObject t_object = Instantiate(monster, this.gameObject.transform);
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
}