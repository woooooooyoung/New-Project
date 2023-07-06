using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventorys : MonoBehaviour
{
    #region 싱글톤
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

    #region 대리자
    public delegate void OnSlotCountChange(int value); // delegate를 이용해 대리자를 정의힘
    public OnSlotCountChange onSlotCountChange;       // 대리자 인스턴스화
    #endregion

    public delegate void OnChangeItem(); // delegate를 이용해 대리자를 정의힘
    public OnChangeItem onChangeItem;      // 대리자 인스턴스화

    public List<Items> items = new List<Items>();

    private int slotCnt;
    public int SlotCnt // Slot값이 변경됨
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
        SlotCnt = 5; // 시작하자마자 slotCnt를 4로 초기화
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
