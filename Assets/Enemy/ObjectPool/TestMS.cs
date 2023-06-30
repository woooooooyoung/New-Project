using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class TestMS : MonoBehaviour
{
    public TestMSEnemy enemyPrefab;  // ������ ����
    public Transform[] spawnPoint;  //�� ���� ��ġ�� ���� �迭 ����

    public float spawnTime;         // ���� ���� �ð�
    public float spawnMinTime;      // ���� ������ �ɸ��� �ּ� ���� �ð� 
    public float spawnMaxTime;      // ���� ������ �ɸ��� �ִ� ���� �ð�
    public float timeAfterSpawn;    // ���� ���� �ð� ����

    [SerializeField] int poolSize;  // �ѹ��� �����Ǵ´� ����
    [SerializeField] int maxSize;

    [Header("-x, x and -z, z")]
    [SerializeField] float negativeX;
    [SerializeField] float positiveX;
    // [Header("-z, z")]
    [SerializeField] float negativeZ;
    [SerializeField] float positiveZ;
    [Header("x, z Debug")]
    public float xPos;
    public float zPos;

    private Stack<TestMSEnemy> enemyObj = new Stack<TestMSEnemy>();
    Vector3 enemyXYZ;
    private void Awake()
    {
        //Spawn();
    }
    private void Start()
    {
        timeAfterSpawn = 0f;                                    // ���� ����ð� 0���� �ʱ�ȭ
        spawnTime = Random.Range(spawnMinTime, spawnMaxTime);   // ���� �����ð��� �ּ� �����ð����� �ִ� �����ð� ���̿��� �����ϱ�
        //xPos = Random.Range(-5, 5);
        //zPos = Random.Range(-5, 5);
        //enemyXYZ = new Vector3(xPos, 0, zPos);
        //for (int i = 0; i < 10; i++)                          // ���͸� �ִ� 10������ ���� 
        //{
        //    TestMSEnemy enemy = Instantiate(enemyPrefab.transform.position + enemyXYZ);      // ���� �ν��Ͻ��� �����
        //    enemy.gameObject.SetActive(true);                  // ��Ȱ��ȭ
        //}
        
    }
    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        xPos = Random.Range(negativeX, positiveX);
        zPos = Random.Range(negativeZ, positiveZ);
        enemyXYZ = new Vector3(xPos, 0, zPos); // �����Ǵ� ��ġ���� x�� xPos��ŭ z�� zPos��ŭ�� ��ġ���� ����
            timeAfterSpawn += Time.deltaTime; // ��������ð��� ���������� �ð� ���ϱ�
        if (timeAfterSpawn >= spawnTime)  // ��������ð��� ���� �����ð����� ũ�ų� ������ ����
        {
            for (int i = 0; i < poolSize; i++) // i�� 0 for�� �ѹ� ����ɶ����� i�� 1�� �ö� i�� 
            {
                int spawnPos = Random.Range(0, spawnPoint.Length); // ù��°�� ������ ������ ������ spawnPos�� �����Ѵ�

                //�׸��� ���� �����ϴµ� ���� �� ���� ��ġ ���� ȸ������ �����Ͽ� ���� �������ش�
                TestMSEnemy enemy = Instantiate(enemyPrefab, spawnPoint[spawnPos].position + enemyXYZ, spawnPoint[spawnPos].rotation);
                timeAfterSpawn = 0f; // timeAfterSpawn�� 0���� �ʱ�ȭ ���ش�
            }
        }
    }
    public TestMSEnemy Get()
    {
        if (enemyObj.Count > 0)
        {
            TestMSEnemy testEnemy = enemyObj.Pop();
            testEnemy.gameObject.SetActive(true);
            testEnemy.transform.parent = null;
            return testEnemy;
        }
        else
        {
            TestMSEnemy testEnemy = Instantiate(enemyPrefab);
            return testEnemy;
        }
    }
    private void Release(TestMSEnemy testMSEnemy)
    {
        if (enemyObj.Count < maxSize)
        {
            testMSEnemy.gameObject.SetActive(false);
            testMSEnemy.transform.SetParent(transform);
            enemyObj.Push(testMSEnemy); // Push�� ��ȯ
        }
        else
        {
            Destroy(testMSEnemy);
        }
    }


    ///* 2. Ȱ��ȭ



    // 3. ����

    /*abstract class Enemy
    {
        public void Dies()
        {
            Debug.Log("dd");
        }
        public abstract void Die();


    }
    class Enemy1 : Enemy
    {
        public override void Die()
        {
            //gameObject.SetActive(false);
            //hpBar.SetActive(false);

            //GetComponent<MonsterAttack>().enemies.Clear();
            //GetComponent<MonsterState>().detected.Clear();

            //MonsterSpawner.instance.InsertQueue(gameObject);
        }
    }*/
















    /*
    [SerializeField] Poolable enemyPrefab;
    //public static Poolable enemyPrefab;

    [SerializeField] float xPos;  // ������ ���� x��ġ
    [SerializeField] float zPos;  // ������ ���� z��ġ 

    private Vector3 RandomVector; // ���� �������� �����Ǳ� ���� ���Ͱ�
    private Stack<Poolable> enemyPool = new Stack<Poolable>();

    private void Start()
    {
        for ( int i = 0; i < 10; i++ ) // i�� 10���� Ŀ�������� �ݺ�
        {
            Poolable poolable = Instantiate(enemyPrefab);
            poolable.gameObject.SetActive(false);
            poolable.transform.SetParent(transform);
            //poolable.Pool = this;
            enemyPool.Push(poolable);
        }
        StartCoroutine(MonsterSpawn());
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
            //if (m_queue.Count != 0)
            //{
            //    xPos = Random.Range(-5, 5);
            //    zPos = Random.Range(-5, 5);
            //    RandomVector = new Vector3(xPos, 0.0f, zPos);
            //    GameObject t_object = GetQueue();
            //    t_object.transform.position = gameObject.transform.position + RandomVector;
            //}
            yield return new WaitForSeconds(1f);
        }
    }*/



























    /*[SerializeField] int enemyCount = 0;            // ���� ����
    [SerializeField] int keepEnemyCount = 0;        // ������ ���� ����

    [SerializeField] Vector3 spawnPos;              // ������ ��ġ
    [SerializeField] float spawnRadius = 15.0f;     // ������ġ
    [SerializeField] float spawnTime = 5.0f;        // �����ð�

    //public GameObject spawn(Define)
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }*/
}
