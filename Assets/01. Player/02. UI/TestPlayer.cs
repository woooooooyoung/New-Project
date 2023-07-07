using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [Header("인벤토리")]
    public Inventory inventory;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 게임을 플레이하면 RaycaseHit2D가 클릭된 곳에 오브젝트가 있나 체크합니다.
            // 만약 오브젝트를 클릭했다면 HitCheckObject(hit) 함수로 hit 정보를 넘겨줍니다.
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
        // 클릭된 오브젝트의 IObjectItem 인터페이스를 clickInterface에 넘겨줍니다.
        // 물론 클릭된 오브젝트가 아이템이 아닐 수 있기에 null 일 수도 있습니다.
        IObjectItem clickInterface = hit.transform.gameObject.GetComponent<IObjectItem>();

        // 만약 clickInterface가 null 이 아니면 (인터페이스를 가지고 있다면)
        // item에 클릭된 오브젝트의 아이템 정보를 넘겨줍니다.
        // 위쪽 ObjectItem.cs의 ClickItem()을 참고
        if (clickInterface != null)
        {
            Item item = clickInterface.ClickItem();
            print($"{item.itemName}");
            inventory.AddItem(item);
        }
    }
}
