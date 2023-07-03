using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjPool : MonoBehaviour
{
    // �׽�Ʈ
    public float min;
    public float max;
    public float time0;
    public float time1;


    // ���� ����
    public Poolable enemyPrefab;  // ������ ����
    public Transform[] spawnPoint;  //�� ���� ��ġ�� ���� �迭 ����
    // ���� �ð�
    public float woaldTime;
    // ���� ���� ����
    [SerializeField] float poolSize; // �Լ��� �ѹ� �ݺ��ɶ����� �����Ǵ� ���� ����
    [SerializeField] int maxSize;    // ���� �ִ� ���� ����
    // ���� ���� �ð�
    public float spawnTime;         // ���� ���� �ð�
    public float spawnMinTime;      // ���� ������ �ɸ��� �ּ� ���� �ð� 
    public float spawnMaxTime;      // ���� ������ �ɸ��� �ִ� ���� �ð�
    // ���� ���� ��ǥ
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
        woaldTime = 0f; // ���ӽ��۽� ���� ������ ���� �ð��� 0���� �ʱ�ȭ   
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
