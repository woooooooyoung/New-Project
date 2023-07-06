using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventorys : MonoBehaviour
{
    #region �̱���
    public static Inventorys instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    #region �븮��
    public delegate void OnSlotCountChange(int value); // delegate�� �̿��� �븮�ڸ� ������
    public OnSlotCountChange onSlotCountChange;       // �븮�� �ν��Ͻ�ȭ
    #endregion

    public delegate void OnChangeItem(); // delegate�� �̿��� �븮�ڸ� ������
    public OnChangeItem onChangeItem;      // �븮�� �ν��Ͻ�ȭ

    public List<Items> items = new List<Items>();

    private int slotCnt;
    public int SlotCnt // Slot���� �����
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }
    void Start()
    {
        SlotCnt = 5; // �������ڸ��� slotCnt�� 4�� �ʱ�ȭ
    }

    public bool AddItem(Items _items)
    {
        if (items.Count < SlotCnt)
        {
            items.Add(_items);
            if(onChangeItem != null)
            onChangeItem.Invoke();
            return true;
        }
        return false;
    }
    public void RemoveItem(int _inDex)
    {
        items.RemoveAt(_inDex);
        onChangeItem.Invoke();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("FieldItem"))
            {
            FieldItems fieldItems = collision.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem()))
            {
                fieldItems.DestroyItem();
            }
        }
    }
}
