using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public bool more = true;
    private static ObjectPooler instance;
    // 1. ��𼭵� ���� ���� (�̱���)
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(this.gameObject);
        }
    }
    // 2. ��� ������Ʈ�� �̸� ���� �� Ȱ��ȭ�� ����
    // 3. �� ������Ʈ�� List���� ���ձ��� �־���
    private void Start()
    {
        CreateBullet();
    }

    public GameObject bullet;
    private List<GameObject> bulletPool;
    public int bulletCreateCount;
    private void CreateBullet()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < bulletCreateCount; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
    }
    // 4. �� ������Ʈ�� �ٸ� ��ũ��Ʈ���� �ʿ��ϸ� ����ϰԲ� Get �Լ��� �������
    public GameObject GetBullet()
    {
        foreach (GameObject obj in bulletPool)
        {
            if (!obj.activeInHierarchy) { return obj; }
        }

        //������Ʈ�� ��� Ȱ��ȭ�� ��
        if (more)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            bulletPool.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }
}
