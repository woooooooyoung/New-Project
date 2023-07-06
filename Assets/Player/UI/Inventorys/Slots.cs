using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour, IPointerUpHandler
{
    public int slotnum;
    public Items items;         // 변수
    public Image itemicon;      // 변수

    public void UpdateSlotUI()  // 매서드 생성
    {
        // 아이템 이미지를 초기화하고 활성화
        itemicon.sprite = items.itemImage;
        itemicon.gameObject.SetActive(true);
    }
    public void RemoveSlot()    // 매서드 생성
    {
        // 아이템은 null로 활성화를 꺼줌
        items = null;
        itemicon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bool isUse = items.Use();
        if(isUse)
        {
            Inventorys.instance.RemoveItem(slotnum);
        }
    }
}
