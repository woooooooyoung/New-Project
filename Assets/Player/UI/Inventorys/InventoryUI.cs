using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventorys invens;

    public GameObject invetoryPanel;
    bool activInvetory = false;

    public Slots[] slots;            // Slot 형식 변수를 배열로 선언
    public Transform slotHolder;    // Transform형 변수를 선언하고 slotHolder라고 함
    private void Start()
    {
        invens = Inventorys.instance;
        slots = slotHolder.GetComponentsInChildren<Slots>(); // 자식 오브젝트들의 원하는 컴포넌트들을 한번에 가지고 옴
        invens.onSlotCountChange += SlotChange;// inventorys스크립트가 참조할 onSlotCoountChange 메서드를 정의 후 생성(CTRL+.으로 매서드 생성)
        invens.onChangeItem += RedrawSlotUI; // 획득한 아이템 화면에 띄우기
        invetoryPanel.SetActive(activInvetory);
    }



    private void SlotChange(int value)
    {
        for (int i = 0; i< slots.Length; i++) // 이 매서드에서 slotsChans 갯수만큼만 슬롯을 활성화하고 나머지는 비활성화
        {
            slots[i].slotnum = i;
            if ( i<invens.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;     // 활성화
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;   // 비활성화
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activInvetory = !activInvetory;
            invetoryPanel.SetActive(activInvetory);
        }
    }

    public void AddSlot() // AddSlot 매서드를 만들고 SlotCnt 증가
    {
        invens.SlotCnt = invens.SlotCnt + 5;
    }
    private void RedrawSlotUI()
    {
        for (int i = 0; i< slots.Length; i++) // 반복문을 통해 슬롯 초기화
        {
            slots[i].RemoveSlot(); // item의 갯수만큼 슬롯을 채움
        }
        for (int i = 0; i < invens.items.Count; i++)
        {
            slots[i].items = invens.items[i];
            slots[i].UpdateSlotUI();
        }
    }
}
