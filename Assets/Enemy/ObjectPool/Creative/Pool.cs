using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

//public class Pool<T> where T : new()
public class Pool : MonoBehaviour
{
    private static Pool Instance;
    [Serializable] public class QueueData
    {
        public int num;     
        public string QueueName;
        public GameObject prefab;
    }
    [SerializeField] public QueueData[] Objects;
    public Dictionary<string, Queue<GameObject>> QueueDic = new Dictionary<string, Queue<GameObject>>();
    private int DictionaryIndex;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // private static Pool instance;
        }
        InitQueue();
    }
    private void InitQueue()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            QueueDic.Add(Objects[i].QueueName, new Queue<GameObject>());

            for (int j = 0; j < Objects[i].num; j++)
            {
                QueueDic[Objects[i].QueueName].Enqueue(CreateNewObject(Objects[i].prefab));
            }
        }
    }

    private GameObject CreateNewObject(GameObject obj)
    {
        var newObj = Instantiate(obj);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    void CheckDictionaryIndex(string key)
    {
        for (int i = 0; i < QueueDic.Count; i++)
        {
            if (QueueDic.ContainsKey(key))
            {
                DictionaryIndex = i;
                break;
            }
        }
    }

    public static GameObject GetObject(Queue<GameObject> objQueue, string key)
    {
        if (objQueue.Count > 0)
        {
            var oldObj = objQueue.Dequeue();
            oldObj.transform.SetParent(null);
            oldObj.gameObject.SetActive(true);
            return oldObj;
        }
        else
        {
            Instance.CheckDictionaryIndex(key);
            var newObj = Instance.CreateNewObject(Instance.Objects[Instance.DictionaryIndex].prefab);
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Queue<GameObject> objQueue, GameObject obj)
    {
        obj.GetComponentInChildren<Rigidbody>().velocity = Vector3.zero;
        obj.gameObject.SetActive(false);
        obj.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        obj.transform.SetParent(Instance.transform);
        objQueue.Enqueue(obj);
    }
}
