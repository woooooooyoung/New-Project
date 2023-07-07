using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class FieldItems : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;
    //public MeshRenderer images;
    public void SetItem(Item _items) // SetItem �ż��� ���� �� �Ű������� Items�� ���� 
    {
        //���޹��� Item�� ���� Ŭ������ Items�� �ʱ�ȭ
        item.itemName = _items.itemName;
        item.itemImage = _items.itemImage;
        item.ItemTape = _items.ItemTape;
        item.efts = _items.efts;

        // �����ۿ� �°� SPrite ����
        image.sprite = _items.itemImage;
        // = _items.itemImage;

    }
    public Item GetItem() // �������� ȹ������ �� ����� GetItem �ż��带 ����
    {
        return item;
    }
    public void DestroyItem()// �������� ȹ���ϸ� �ʵ��� �������� �ı��� �ż���
    {
        Destroy(gameObject);
    }
}
