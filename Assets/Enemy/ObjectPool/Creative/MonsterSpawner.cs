using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Poolable enemyPrefab;  // 생성할 몬스터
    public Transform[] spawnPoint;  //적 생성 위치를 담은 배열 변수

    public float spawnTime;         // 몬스터 생성 시간
    public float spawnMinTime;      // 몬스터 생성에 걸리는 최소 생성 시간 
    public float spawnMaxTime;      // 몬스터 생성에 걸리는 최대 생성 시간
    public float timeAfterSpawn;    // 게임 진행 시간 변수

    [SerializeField] int poolSize;  // 한번에 생성되는는 몬스터
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

    private Stack<Poolable> enemyObj = new Stack<Poolable>();
    Vector3 enemyXYZ;
    private void Awake()
    {
        //Spawn();
    }
    private void Start()
    {
        timeAfterSpawn = 0f;                                    // 게임 진행시간 0으로 초기화
        spawnTime = Random.Range(spawnMinTime, spawnMaxTime);   // 몬스터 생성시간을 최소 생성시간에서 최대 생성시간 사이에서 생성하기
        //xPos = Random.Range(-5, 5);
        //zPos = Random.Range(-5, 5);
        //enemyXYZ = new Vector3(xPos, 0, zPos);
        //for (int i = 0; i < 10; i++)                          // 몬스터를 최대 10개까지 생성 
        //{
        //    TestMSEnemy enemy = Instantiate(enemyPrefab.transform.position + enemyXYZ);      // 몬스터 인스턴스로 만들기
        //    enemy.gameObject.SetActive(true);                  // 비활성화
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
        enemyXYZ = new Vector3(xPos, 0, zPos); // 생성되는 위치에서 x는 xPos만큼 z는 zPos만큼의 위치에서 생성
        timeAfterSpawn += Time.deltaTime; // 게임진행시간에 지속적으로 시간 더하기
        if (timeAfterSpawn >= spawnTime)  // 게임진행시간이 몬스터 생성시간보다 크거나 같으면 실행
        {
            for (int i = 0; i < poolSize; i++) // i눈 0 for으 한번 실행될때마다 i가 1씩 올라감 i가 
            {
                int spawnPos = Random.Range(0, spawnPoint.Length); // 첫번째로 랜덤한 정수형 변수를 spawnPos에 저장한다

                //그리고 적을 생성하는데 적과 적 생성 위치 적의 회전값을 설정하여 적을 생성해준다
                Poolable enemy = Instantiate(enemyPrefab, spawnPoint[spawnPos].position + enemyXYZ, spawnPoint[spawnPos].rotation);
                timeAfterSpawn = 0f; // timeAfterSpawn을 0으로 초기화 해준다
                Debug.Log(i + "2");
            }
        }
    }
    public Poolable Get()
    {
        if (enemyObj.Count > 0) // enemyObj에 객체가 하나 이상 있는 경우
        {
            Poolable testEnemy = enemyObj.Pop();  // 가져오기
            testEnemy.gameObject.SetActive(true);
            testEnemy.transform.parent = null;
            return testEnemy;
        }
        else
        {
            Poolable testEnemy = Instantiate(enemyPrefab);
            return testEnemy;
        }
    }
    private void Release(Poolable testMSEnemy)
    {
        if (enemyObj.Count < maxSize) //nemyObj에 객체를 추가할 수 있는 여유 공간이 있는지를 확인, 당 리스트의 크기가 최대 크기보다 작은 경우에만 적 객체를 추가하거나 추가 동작을 수행할 수 있습니다.
        {
            testMSEnemy.gameObject.SetActive(false); 
            testMSEnemy.transform.SetParent(transform);
            enemyObj.Push(testMSEnemy); // 저장하기
        }
        else
        {
            Destroy(testMSEnemy);
        }
    }
}


    ///* 2. 활성화



// 3. 죽음

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

[SerializeField] float xPos;  // 생성될 몬스터 x위치
[SerializeField] float zPos;  // 생성될 몬스터 z위치 

private Vector3 RandomVector; // 몬스터 랜덤으로 생성되기 위한 백터값
private Stack<Poolable> enemyPool = new Stack<Poolable>();

private void Start()
{
    for ( int i = 0; i < 10; i++ ) // i가 10보다 커질떄까지 반복
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






