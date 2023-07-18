using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public int slotnum;
    public Item items;         // ����
    public Image itemicon;      // ����

    public void UpdateSlotUI()  // �ż��� ����
    {
        // ������ �̹����� �ʱ�ȭ�ϰ� Ȱ��ȭ
        itemicon.sprite = items.itemImage;
        itemicon.gameObject.SetActive(true);

    }
    public void RemoveSlot()    // �ż��� ����
    {
        // �������� null�� Ȱ��ȭ�� ����
        items = null;
        itemicon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bool isUse = items.Use();
        if (isUse)
        {
            Inventory.instance.RemoveItem(slotnum);
        }
    }
}
    