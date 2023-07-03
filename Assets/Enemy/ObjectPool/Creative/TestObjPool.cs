using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class TestObjPool : MonoBehaviour
{
    // �׽�Ʈ
    //public float min;
    //public float max;
    public float realTimer;
    public float deltatimer;
    public float time;
    public float tsetTime;
    //public float realtime;
    //public float deltaTime;

    // ���� ����
    //public Poolable enemyPrefab;  // ������ ����
    public GameObject[] enemyObjPrefab; // v
    public Transform[] spawnPoint;  //�� ���� ��ġ�� ���� �迭 ����
    // ���� �ð�
    public float woaldTime;
    // ���� ���� ����
    [SerializeField] float enemyPoolSize;   // �Լ��� �ѹ� �ݺ��ɶ����� �����Ǵ� ���� ����
    [SerializeField] int currentEnemyCount; // ���� ���� �� v
    [SerializeField] int maxEnemySize;      // ���� �ִ� ���� ���� v
    //// ���� ���� �ð�
    [SerializeField] float spawnInterval;   // ���� ���� �ð� v
    public float spawnMinTime;      // ���� ������ �ɸ��� �ּ� ���� �ð� 
    public float spawnMaxTime;      // ���� ������ �ɸ��� �ִ� ���� �ð�
    //// ���� ���� ��ǥ
    [Header("-x, x and -z, z")]
    [SerializeField] float negativeX;
    [SerializeField] float positiveX;
    [SerializeField] float negativeZ;
    [SerializeField] float positiveZ;
    [Header("x, z Debug")]
    public float xPos;
    public float zPos;

    private Stack<GameObject> enemem = new Stack<GameObject>();
    //private Stack<Poolable> enemyObj = new Stack<Poolable>();
    Vector3 enemyXYZ;


    private void Start()
    {
        //    // ���ӽ��۽� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        //    woaldTime = 0f; 
        //
        //    // ���� �����ð��� �ּ� �����ð����� �ִ� �����ð� ���̿��� �����ϱ�
        //    spawnTime = Random.Range(spawnMinTime, spawnMaxTime);
        
    }

    void Update()
    {
        realTimer = Time.realtimeSinceStartup;
        deltatimer += Time.deltaTime;
        //Test0();
        TestSpawn();
        //Test1();
        //Test2();
        //Debug.Log(time0);
    }
    private void a2()
    {

    }
    private void Test0()
    {
        xPos = Random.Range(negativeX, positiveX);
        zPos = Random.Range(negativeZ, positiveZ);
        enemyXYZ = new Vector3(xPos, 0, zPos); //�����Ǵ� ��ġ���� x�� xPos��ŭ z�� zPos��ŭ�� ��ġ���� ����

        if (deltatimer >= spawnInterval) //
        {

        }
        if (deltatimer >= spawnInterval && currentEnemyCount < maxEnemySize) // Time.deltaTime�� spawnInterval(���ͻ����ð�)���� ũ�ų� ���ƾ��ϰ�, ���� ������ ���ڰ� �ִ� ������ ���ں��� �۾ƾ���
        {
            SpawnMonster(); // ���� ����
            deltatimer = 0f; // ���� Ÿ�̸� �ʱ�ȭ
                             //for (int i = 0; i < 10; i++)
                             //{
                             //    SpawnMonster(); // ���� ����
                             //    deltatimer = 0f; // ���� Ÿ�̸� �ʱ�ȭ
                             //}


        }
        else if ((deltatimer >= spawnInterval && currentEnemyCount <= maxEnemySize))
        {
            deltatimer = 0f;
        }
    }
    private void SpawnMonster()
    {
        
        GameObject newMonster = Instantiate(enemyObjPrefab[0], transform.position + enemyXYZ, Quaternion.identity);
       //GameObject newMonster1 = Instantiate(enemyObjPrefab[1], transform.position, Quaternion.identity);
       //GameObject newMonster2 = Instantiate(enemyObjPrefab[2], transform.position, Quaternion.identity);
       //GameObject newMonster3 = Instantiate(enemyObjPrefab[3], transform.position, Quaternion.identity);
        // ���� �ʱ�ȭ �� ��ġ ���� �� �߰� �۾� ����

       currentEnemyCount++; // ���� ���� �� ����
       // if (currentEnemyCount <= 10)
       // {
       //     newMonster.gameObject.SetActive(false);
       // }
       // else if (currentEnemyCount >= 10)
       // {
       //     newMonster.gameObject.SetActive(true);
       // }
    }
    private void TestSpawn()
    {
        Debug.Log("2");
        xPos = Random.Range(negativeX, positiveX);
        zPos = Random.Range(negativeZ, positiveZ);
        enemyXYZ = new Vector3(xPos, 0, zPos);
        for (int i = 0; i < 10; i++)
        {
            if (deltatimer >= spawnInterval && i < maxEnemySize)
            {
                SpawnMonster();
                break;
            }
            break;
        }
    }
   // public GameObject Get()
   // {
   //     if (enemem.Count > 0) 
   //     {
   //         GameObject obj = enemem.Pop();
   //         obj.gameObject.SetActive(false);
   //         obj.transform.parent = null;
   //         return obj;
   //     }
   //     else
   //     {
   //         GameObject obj = Instantiate(enemyObjPrefab[0]);
   //         //GameObject obj1 = Instantiate(enemyObjPrefab[1]);
   //         //GameObject obj2 = Instantiate(enemyObjPrefab[2]);
   //         //GameObject obj3 = Instantiate(enemyObjPrefab[3]);
   //         return obj;
   //     }
   // }
   // private void Release(GameObject obj)
   // {
   //     if (enemem.Count < maxEnemySize)
   //     {
   //         obj.gameObject.SetActive(true);
   //         obj.transform.SetParent(transform);
   //         enemem.Push(obj);
   //     }
   //     else
   //     {
   //         Destroy(obj);
   //     }    
   //     //if (obj.gameObject.SetActive(true) < 1)
   // }


    //���� �ִ� ������ �ð� �����ϱ�

    //for (int i = 0; i < 5; i++)
    //{
    //    Debug.Log(i);
    //}

    //time0 = 0;
    //time1 = 0;
    //while (true)
    //{
    //    time0 += Time.deltaTime;
    //    time1 = Time.realtimeSinceStartup;       // ���� ����ð�
    //    if (time1 > realtime)
    //    {
    //        time0 = 0f;
    //        time1 = 0f;
    //        Debug.Log("�ʱ�ȭ");
    //        //for (int i = 0; i < 10; i++)
    //        //{
    //        //    Debug.Log(realtime + "��");
    //        //    time1 = 0;
    //        //}
    //        //Debug.Log(realtime + "��");
    //        //time1 = Time.realtimeSinceStartup;
    //        //time1 = 0;
    //    }
    //}
    //woaldTime += Time.deltaTime;            // �����Ӹ��� �ð� �����ֱ�
    //woaldTime += Time.realtimeSinceStartup; // �����ð����� �����ֱ�
    //ime0 = Time.deltaTime;
    //f (time0 > deltaTime)
    //
    //   Debug.Log("��ŸŸ�� �ʱ�ȭ");
    //   time0 = 0;
    //
    //if (time1 > realtime)
    //{
    //    Debug.Log("����Ÿ�� �ʱ�ȭ");
    //    time1 = 0;
    //    for (int i = 0; i < 10; i++)
    //    {
    //        Debug.Log("����Ÿ�� �ʱ�ȭ1");
    //        time1 = 0;
    //    }
    //}



    //if (time0 >= 5)
    //{
    //    for (int i = 0; i < max; i++)
    //    {
    //        time0 = 0f;
    //
    //    }
    //}


    //private void Test1()
    //{
    //    /*//time1 += Time.deltaTime;
    //    for (int i = 0; i < 10; i++)
    //    {
    //        //time1 += Time.deltaTime;
    //        //Debug.Log(time1);
    //        Debug.Log(i);
    //        if (i >= 9)
    //        {
    //            //Debug.Log(time1);
    //        }
    //        
    //    }*/
    //}
    //private void Test2()
    //{
    //    /*for (int i = 0; i < max; i++)
    //    {
    //        Debug.Log(i);
    //    }*/
    //}
}
