using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjPool : MonoBehaviour
{
    // 테스트
    public float min;
    public float max;
    public float time0;
    public float time1;


    // 몬스터 정보
    public Poolable enemyPrefab;  // 생성할 몬스터
    public Transform[] spawnPoint;  //적 생성 위치를 담은 배열 변수
    // 월드 시간
    public float woaldTime;
    // 몬스터 생성 갯수
    [SerializeField] float poolSize; // 함수가 한번 반복될때마다 생성되는 몬스터 갯수
    [SerializeField] int maxSize;    // 몬스터 최대 생성 갯수
    // 몬스터 생성 시간
    public float spawnTime;         // 몬스터 생성 시간
    public float spawnMinTime;      // 몬스터 생성에 걸리는 최소 생성 시간 
    public float spawnMaxTime;      // 몬스터 생성에 걸리는 최대 생성 시간
    // 몬스터 생성 좌표
    [Header("-x, x and -z, z")]
    [SerializeField] float negativeX;
    [SerializeField] float positiveX;
    [SerializeField] float negativeZ;
    [SerializeField] float positiveZ;
    [Header("x, z Debug")]
    public float xPos;
    public float zPos;


    private void Start()
    {
        woaldTime = 0f; // 게임시작시 몬스터 스폰을 위해 시간을 0으로 초기화   
    }
    void Update()
    {
        Test0();
        //Test1();
        //Test2();
        //Debug.Log(time0);
    }


    private void Test0()
    {
        
        time0 += Time.deltaTime;
        if (time0 >= 5)
        {
            for (int i = 0; i < max; i++)
            {
                time0 = 0f;

            }
        }
        
    }
    private void Test1()
    {
        /*//time1 += Time.deltaTime;
        for (int i = 0; i < 10; i++)
        {
            //time1 += Time.deltaTime;
            //Debug.Log(time1);
            Debug.Log(i);
            if (i >= 9)
            {
                //Debug.Log(time1);
            }
            
        }*/
    }
    private void Test2()
    {
        /*for (int i = 0; i < max; i++)
        {
            Debug.Log(i);
        }*/
    }
}
