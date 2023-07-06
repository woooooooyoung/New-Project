using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Items items;
    public SpriteRenderer image;
    //public MeshRenderer images;
    public void SetItem(Items _items) // SetItem �ż��� ���� �� �Ű������� Items�� ���� 
    {
        //���޹��� Items�� ���� Ŭ������ Items�� �ʱ�ȭ
        items.itemName = _items.itemName;
        items.itemImage = _items.itemImage;
        items.ItemTape = _items.ItemTape;
        items.efts = _items.efts;

        // �����ۿ� �°� SPrite ����
        image.sprite = _items.itemImage;
        // = _items.itemImage;

    }
    public Items GetItem() // �������� ȹ������ �� ����� GetItem �ż��带 ����
    {
        return items;
    }
    public void DestroyItem()// �������� ȹ���ϸ� �ʵ��� �������� �ı��� �ż���
    {
        Destroy(gameObject);
    }
}
