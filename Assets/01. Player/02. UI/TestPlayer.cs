using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [Header("�κ��丮")]
    public Inventory inventory;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ������ �÷����ϸ� RaycaseHit2D�� Ŭ���� ���� ������Ʈ�� �ֳ� üũ�մϴ�.
            // ���� ������Ʈ�� Ŭ���ߴٸ� HitCheckObject(hit) �Լ��� hit ������ �Ѱ��ݴϴ�.
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                HitCheckObject(hit);
            }
        }
    }

    void HitCheckObject(RaycastHit2D hit)
    {
        // Ŭ���� ������Ʈ�� IObjectItem �������̽��� clickInterface�� �Ѱ��ݴϴ�.
        // ���� Ŭ���� ������Ʈ�� �������� �ƴ� �� �ֱ⿡ null �� ���� �ֽ��ϴ�.
        IObjectItem clickInterface = hit.transform.gameObject.GetComponent<IObjectItem>();

        // ���� clickInterface�� null �� �ƴϸ� (�������̽��� ������ �ִٸ�)
        // item�� Ŭ���� ������Ʈ�� ������ ������ �Ѱ��ݴϴ�.
        // ���� ObjectItem.cs�� ClickItem()�� ����
        if (clickInterface != null)
        {
            Item item = clickInterface.ClickItem();
            print($"{item.itemName}");
            inventory.AddItem(item);
        }
    }
}
