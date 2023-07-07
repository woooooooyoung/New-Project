using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class FieldItems : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;
    //public MeshRenderer images;
    public void SetItem(Item _items) // SetItem 매서드 생성 후 매개변수로 Items를 가짐 
    {
        //전달받은 Item로 현재 클래스의 Items를 초기화
        item.itemName = _items.itemName;
        item.itemImage = _items.itemImage;
        item.ItemTape = _items.ItemTape;
        item.efts = _items.efts;

        // 아이템에 맞게 SPrite 변경
        image.sprite = _items.itemImage;
        // = _items.itemImage;

    }
    public Item GetItem() // 아이템을 획득했을 때 사용할 GetItem 매서드를 만듬
    {
        return item;
    }
    public void DestroyItem()// 아이템을 획득하면 필드의 아이템을 파괴할 매서드
    {
        Destroy(gameObject);
    }
}
