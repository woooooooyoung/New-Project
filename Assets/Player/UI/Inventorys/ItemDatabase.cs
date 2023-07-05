using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;
    }

    public List<Items> itemDB = new List<Items>();

    public GameObject fildItemPrefab;    // FildItem 프리팹을 복제하기 위한 변수
    public Vector3[] pos;               // 생성할 위치를 정할 Vector3배열
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject go = Instantiate(fildItemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 3)]);
        }
    }
}
