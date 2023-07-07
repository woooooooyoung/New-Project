using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
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
    //public GameObject[] enemyObjPrefab; // v
    public GameObject enemyObjPrefab;
    public Poolable enemyPrefab;
    public Transform[] spawnPoint;  // 적 생성 위치를 담은 배열 변수 
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

    private Stack<GameObject> enemem;// = new Stack<GameObject>();
    //private Stack<Poolable> enemyObj = new Stack<Poolable>();
    Vector3 enemyXYZ;
    private void Start()
    {
        enemem = new Stack<GameObject>();
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
        Spawner();
        //Spawn();
    }

    private void Spawner()
    {
        xPos = Random.Range(-negativeX, positiveX);
        zPos = Random.Range(-negativeZ, positiveZ);
        enemyXYZ = new Vector3(xPos, 0, zPos); //생성되는 위치에서 x는 xPos만큼 z는 zPos만큼의 위치에서 생성
        if ( deltatimer >= spawnInterval && maxEnemySize > currentEnemyCount)
        {
            
            deltatimer = 0;
            for (int i = 0; i < maxEnemySize; i++)
            {
                int spawnPos = Random.Range(0, spawnPoint.Length);
                SpawnMonster();
            }
        }
    }
    private void Spawn()
    {
        xPos = Random.Range(negativeX, positiveX);
        zPos = Random.Range(negativeZ, positiveZ);
        enemyXYZ = new Vector3(xPos, 0, zPos); // 생성되는 위치에서 x는 xPos만큼 z는 zPos만큼의 위치에서 생성
        if (deltatimer >= spawnInterval && maxEnemySize > currentEnemyCount)  // 게임진행시간이 몬스터 생성시간보다 크거나 같으면 실행
        {
            deltatimer = 0f;
            for (int i = 0; i < maxEnemySize; i++) // i눈 0 for으 한번 실행될때마다 i가 1씩 올라감 i가 
            {
                int spawnPos = Random.Range(0, spawnPoint.Length); // 첫번째로 랜덤한 정수형 변수를 spawnPos에 저장한다

                //그리고 적을 생성하는데 적과 적 생성 위치 적의 회전값을 설정하여 적을 생성해준다
                Poolable enemy = Instantiate(enemyPrefab, spawnPoint[spawnPos].position + enemyXYZ, spawnPoint[spawnPos].rotation);
                //deltatimer = 0f; // timeAfterSpawn을 0으로 초기화 해준다
                Debug.Log(i + "2");
                currentEnemyCount++;
            }
        }
    }
    private void SpawnMonster()
    {

        //GameObject newMonster = Instantiate(enemyObjPrefab[0], transform.position + enemyXYZ, Quaternion.identity);
        GameObject newMonster = Instantiate(enemyObjPrefab, transform.position + enemyXYZ, Quaternion.identity);
        // 몬스터 초기화 및 위치 설정 등 추가 작업 수행
        currentEnemyCount++; // 현재 몬스터 수 증가
    }
}
