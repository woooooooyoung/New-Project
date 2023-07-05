using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image; // Image의 컴포넌트 넣기

    private Item _item;
    public Item item
    {
        get
        {
            return _item;   // slot의 아이템 정보를 넘겨줄 때
        }
        set
        { _item = value;
            if (_item != null)  // item에 들어오는 정보의 값을 _item에 저장
            {
                image.sprite = item.itemImage;       // 인벤토리에 List<Item> items에 등록된 아이템이 있다면 itemImage를 image에 저장
                image.color = new Color(1, 1, 1, 1); // Image의 알파 값을 1로 하여 이미지를 표시함
            }
            else                                     // item이 null일 때
            {
                image.color = new Color(1, 1, 1, 0); // Image의 알파 값 0을 주어 화면에 표시하지 않음
            }
        }
    }
}       
