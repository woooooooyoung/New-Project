using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPools : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize;

    [Header("-x, x and -z, z")]
    [SerializeField] float negativeX;
    [SerializeField] float positiveX;
    [SerializeField] float negativeZ;
    [SerializeField] float positiveZ;
    [Header("x, z Debug")]
    public float xPos;
    public float zPos;
    Vector3 enemyXYZ;

    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();
        xPos = Random.Range(negativeX, positiveX);
        zPos = Random.Range(negativeZ, positiveZ);
        enemyXYZ = new Vector3(xPos, 0, zPos);
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }
    private GameObject GetObj()
    {
        for (int i = 0; i < objectPool.Count
            ; i++)
        {
            if (!objectPool[i].activeInHierarchy )
            {
                return objectPool[i];
            }
        }
        return null;
    }

    private void ActivateObjectFromPool()
    {
        GameObject obj = GetObj();

        if (obj != null)
        {
            obj.SetActive(true);
        }
    }
    
}
