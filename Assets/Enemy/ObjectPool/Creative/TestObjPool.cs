using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class TestObjPool : MonoBehaviour
{
    // 테스트
    //public float min;
    //public float max;
    public float realTimer;
    public float deltatimer;
    public float time;
    public float tsetTime;
    //public float realtime;
    //public float deltaTime;

    // 몬스터 정보
    //public Poolable enemyPrefab;  // 생성할 몬스터
    public GameObject[] enemyObjPrefab; // v
    public Transform[] spawnPoint;  //적 생성 위치를 담은 배열 변수
    // 월드 시간
    public float woaldTime;
    // 몬스터 생성 갯수
    [SerializeField] float enemyPoolSize;   // 함수가 한번 반복될때마다 생성되는 몬스터 갯수
    [SerializeField] int currentEnemyCount; // 현재 몬스터 수 v
    [SerializeField] int maxEnemySize;      // 몬스터 최대 생성 갯수 v
    //// 몬스터 생성 시간
    [SerializeField] float spawnInterval;   // 몬스터 생성 시간 v
    public float spawnMinTime;      // 몬스터 생성에 걸리는 최소 생성 시간 
    public float spawnMaxTime;      // 몬스터 생성에 걸리는 최대 생성 시간
    //// 몬스터 생성 좌표
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
        //    // 게임시작시 몬스터 스폰을 위해 시간을 0으로 초기화
        //    woaldTime = 0f; 
        //
        //    // 몬스터 생성시간을 최소 생성시간에서 최대 생성시간 사이에서 생성하기
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
        enemyXYZ = new Vector3(xPos, 0, zPos); //생성되는 위치에서 x는 xPos만큼 z는 zPos만큼의 위치에서 생성

        if (deltatimer >= spawnInterval) //
        {

        }
        if (deltatimer >= spawnInterval && currentEnemyCount < maxEnemySize) // Time.deltaTime이 spawnInterval(몬스터생성시간)보다 크거나 같아야하고, 현재 몬스터의 숫자가 최대 몬스터의 숫자보다 작아야함
        {
            SpawnMonster(); // 몬스터 스폰
            deltatimer = 0f; // 스폰 타이머 초기화
                             //for (int i = 0; i < 10; i++)
                             //{
                             //    SpawnMonster(); // 몬스터 스폰
                             //    deltatimer = 0f; // 스폰 타이머 초기화
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
        // 몬스터 초기화 및 위치 설정 등 추가 작업 수행

       currentEnemyCount++; // 현재 몬스터 수 증가
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


    //몬스터 최대 갯수와 시간 설정하기

    //for (int i = 0; i < 5; i++)
    //{
    //    Debug.Log(i);
    //}

    //time0 = 0;
    //time1 = 0;
    //while (true)
    //{
    //    time0 += Time.deltaTime;
    //    time1 = Time.realtimeSinceStartup;       // 게임 경과시간
    //    if (time1 > realtime)
    //    {
    //        time0 = 0f;
    //        time1 = 0f;
    //        Debug.Log("초기화");
    //        //for (int i = 0; i < 10; i++)
    //        //{
    //        //    Debug.Log(realtime + "초");
    //        //    time1 = 0;
    //        //}
    //        //Debug.Log(realtime + "초");
    //        //time1 = Time.realtimeSinceStartup;
    //        //time1 = 0;
    //    }
    //}
    //woaldTime += Time.deltaTime;            // 프레임마다 시간 더해주기
    //woaldTime += Time.realtimeSinceStartup; // 실제시간마다 더해주기
    //ime0 = Time.deltaTime;
    //f (time0 > deltaTime)
    //
    //   Debug.Log("델타타임 초기화");
    //   time0 = 0;
    //
    //if (time1 > realtime)
    //{
    //    Debug.Log("리얼타임 초기화");
    //    time1 = 0;
    //    for (int i = 0; i < 10; i++)
    //    {
    //        Debug.Log("리얼타임 초기화1");
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
