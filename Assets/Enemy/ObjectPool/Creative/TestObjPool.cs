using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
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
    //public GameObject[] enemyObjPrefab; // v
    public GameObject enemyObjPrefab;
    public Poolable enemyPrefab;
    public Transform[] spawnPoint;  // �� ���� ��ġ�� ���� �迭 ���� 
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

    private Stack<GameObject> enemem;// = new Stack<GameObject>();
    //private Stack<Poolable> enemyObj = new Stack<Poolable>();
    Vector3 enemyXYZ;
    private void Start()
    {
        enemem = new Stack<GameObject>();
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
        Spawner();
        //Spawn();
    }

    private void Spawner()
    {
        xPos = Random.Range(-negativeX, positiveX);
        zPos = Random.Range(-negativeZ, positiveZ);
        enemyXYZ = new Vector3(xPos, 0, zPos); //�����Ǵ� ��ġ���� x�� xPos��ŭ z�� zPos��ŭ�� ��ġ���� ����
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
        enemyXYZ = new Vector3(xPos, 0, zPos); // �����Ǵ� ��ġ���� x�� xPos��ŭ z�� zPos��ŭ�� ��ġ���� ����
        if (deltatimer >= spawnInterval && maxEnemySize > currentEnemyCount)  // ��������ð��� ���� �����ð����� ũ�ų� ������ ����
        {
            deltatimer = 0f;
            for (int i = 0; i < maxEnemySize; i++) // i�� 0 for�� �ѹ� ����ɶ����� i�� 1�� �ö� i�� 
            {
                int spawnPos = Random.Range(0, spawnPoint.Length); // ù��°�� ������ ������ ������ spawnPos�� �����Ѵ�

                //�׸��� ���� �����ϴµ� ���� �� ���� ��ġ ���� ȸ������ �����Ͽ� ���� �������ش�
                Poolable enemy = Instantiate(enemyPrefab, spawnPoint[spawnPos].position + enemyXYZ, spawnPoint[spawnPos].rotation);
                //deltatimer = 0f; // timeAfterSpawn�� 0���� �ʱ�ȭ ���ش�
                Debug.Log(i + "2");
                currentEnemyCount++;
            }
        }
    }
    private void SpawnMonster()
    {

        //GameObject newMonster = Instantiate(enemyObjPrefab[0], transform.position + enemyXYZ, Quaternion.identity);
        GameObject newMonster = Instantiate(enemyObjPrefab, transform.position + enemyXYZ, Quaternion.identity);
        // ���� �ʱ�ȭ �� ��ġ ���� �� �߰� �۾� ����
        currentEnemyCount++; // ���� ���� �� ����
    }
}
