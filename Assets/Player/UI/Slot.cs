using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image; // Image�� ������Ʈ �ֱ�

    private Item _item;
    public Item item
    {
        get
        {
            return _item;   // slot�� ������ ������ �Ѱ��� ��
        }
        set
        { _item = value;
            if (_item != null)  // item�� ������ ������ ���� _item�� ����
            {
                image.sprite = item.itemImage;       // �κ��丮�� List<Item> items�� ��ϵ� �������� �ִٸ� itemImage�� image�� ����
                image.color = new Color(1, 1, 1, 1); // Image�� ���� ���� 1�� �Ͽ� �̹����� ǥ����
            }
            else                                     // item�� null�� ��
            {
                image.color = new Color(1, 1, 1, 0); // Image�� ���� �� 0�� �־� ȭ�鿡 ǥ������ ����
            }
        }
    }
}       
