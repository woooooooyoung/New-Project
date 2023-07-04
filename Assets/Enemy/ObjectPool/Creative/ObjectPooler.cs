using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public bool more = true;
    private static ObjectPooler instance;
    // 1. 어디서든 접근 가능 (싱글톤)
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
    // 2. 어떠한 오브젝트를 미리 생성 후 활성화를 꺼줌
    // 3. 그 오브젝트를 List같은 집합군에 넣어줌
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
    // 4. 그 오브젝트를 다른 스크립트에서 필요하면 사용하게끔 Get 함수를 만들어줌
    public GameObject GetBullet()
    {
        foreach (GameObject obj in bulletPool)
        {
            if (!obj.activeInHierarchy) { return obj; }
        }

        //오브젝트가 모두 활성화일 때
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
