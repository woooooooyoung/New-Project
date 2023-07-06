using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Items items;
    public SpriteRenderer image;
    //public MeshRenderer images;
    public void SetItem(Items _items) // SetItem 매서드 생성 후 매개변수로 Items를 가짐 
    {
        //전달받은 Items로 현재 클래스의 Items를 초기화
        items.itemName = _items.itemName;
        items.itemImage = _items.itemImage;
        items.ItemTape = _items.ItemTape;
        items.efts = _items.efts;

        // 아이템에 맞게 SPrite 변경
        image.sprite = _items.itemImage;
        // = _items.itemImage;

    }
    public Items GetItem() // 아이템을 획득했을 때 사용할 GetItem 매서드를 만듬
    {
        return items;
    }
    public void DestroyItem()// 아이템을 획득하면 필드의 아이템을 파괴할 매서드
    {
        Destroy(gameObject);
    }
}
