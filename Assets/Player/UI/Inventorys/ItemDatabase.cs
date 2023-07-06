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

    public GameObject fildItemPrefab;    // FildItem �������� �����ϱ� ���� ����
    public Vector3[] pos;               // ������ ��ġ�� ���� Vector3�迭
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject go = Instantiate(fildItemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 3)]);
        }
    }
}
