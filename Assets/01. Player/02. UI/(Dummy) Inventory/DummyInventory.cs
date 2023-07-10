using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//public class Inventory : MonoBehaviour
//{
//    public List<Item> items;                                // 아이템을 담을 리스트
//    [SerializeField] private TrackedReference slotParent;   // 위의 이미지처럼 Slot의 부모가 되는 Bag을 담을 곳
//    [SerializeField] private Slot[] slots;                  // Bag의 하위에 등록된 Slot을 담을 곳
//
//    private void OnValidate()                               // OnValidate()의 기능은 유니티 에디터에서 바로 작동을 하는 역할
//    {
//        slots = GetComponentsInChildren<Slot>();            // 처음 인벤토리에 소스를 등록하시면 Console창에 에러가 뜨지만 Bag을 넣어 주시면 
//                                                            // slots에 Slot들이 자동 등록이 됨
//    }
//    private void Awake()
//    {
//        FreshSlot();                                        // 게임이 시작되면 items에 들어 있는 아이템을 인벤토리에 넣어 줍니다.
//    }
//    public void FreshSlot()                                 // FreshSlot의 역할은 아이템이 들어오거나 나가면 Slot의 내용을 다시 정리하여 화면에 보여 주는 기능
//    {
//        int i = 0;                                          // int i = 0을 외부에 선언한 건 두 개의 For 문에 같은 i의 값을 사용하기 위해서입니다.
//        for (; i < items.Count && i < slots.Length; i++)    // 첫 for문은 items에 들어 있는 수만큼 slots에 차례대로 item을 넣어 줍니다.
//        {                                                   // "i < items.Count && i < slots.Length" i의 값이 items와 slots 두 개의 값 보다 작아야만 돌아가는 구조입니다. items의 수가 slots 수보다 많으면 안 되기 때문에
//            slots[i].item = items[i];                       // slot에 item이 들어가면 Slot.cs에 선언된 item의 set 안의 내용이 실행되어 해당 슬롯에 이미지를 표시하게 됩니다
//        }
//        for (; i < slots.Length; i++)                       // 두 번째 for문이 돌 땐 i의 값은 첫 번째 for문에서 사용되고 남은 값부터 시작하게 됩니다. 즉 여기서 i의 값은 슬롯의 순서이며
//        {                                                   // 아이템을 차례대로 i번째 슬롯에 넣고 나머지 i번째 슬롯은 null을 주어 빈 슬롯으로 표시되게 합니다. 
//            slots[i].item = null;                           // slot에 아이템을 다 저장하고 난 후에도 slot이 남아 있다면 다음 for문이 실행되어 빈 슬롯들은 모두 null 처리
//        }
//    }
//    public void AddItem(Item _item)                         // 아이템을 획득할 경우 AddItem을 불러와 넣어 주시면 됩니다.
//    {
//        if (items.Count < slots.Length)
//        {
//            items.Add(_item);
//            FreshSlot();
//        }
//        else
//        {
//            print("빈 공간이 없습니다.");
//        }
//    }
//}
