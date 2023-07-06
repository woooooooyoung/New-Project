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

    public Slots[] slots;            // Slot ���� ������ �迭�� ����
    public Transform slotHolder;    // Transform�� ������ �����ϰ� slotHolder��� ��
    private void Start()
    {
        invens = Inventorys.instance;
        slots = slotHolder.GetComponentsInChildren<Slots>(); // �ڽ� ������Ʈ���� ���ϴ� ������Ʈ���� �ѹ��� ������ ��
        invens.onSlotCountChange += SlotChange;// inventorys��ũ��Ʈ�� ������ onSlotCoountChange �޼��带 ���� �� ����(CTRL+.���� �ż��� ����)
        invens.onChangeItem += RedrawSlotUI; // ȹ���� ������ ȭ�鿡 ����
        invetoryPanel.SetActive(activInvetory);
    }



    private void SlotChange(int value)
    {
        for (int i = 0; i< slots.Length; i++) // �� �ż��忡�� slotsChans ������ŭ�� ������ Ȱ��ȭ�ϰ� �������� ��Ȱ��ȭ
        {
            slots[i].slotnum = i;
            if ( i<invens.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;     // Ȱ��ȭ
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;   // ��Ȱ��ȭ
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

    public void AddSlot() // AddSlot �ż��带 ����� SlotCnt ����
    {
        invens.SlotCnt = invens.SlotCnt + 5;
    }
    private void RedrawSlotUI()
    {
        for (int i = 0; i< slots.Length; i++) // �ݺ����� ���� ���� �ʱ�ȭ
        {
            slots[i].RemoveSlot(); // item�� ������ŭ ������ ä��
        }
        for (int i = 0; i < invens.items.Count; i++)
        {
            slots[i].items = invens.items[i];
            slots[i].UpdateSlotUI();
        }
    }
}
