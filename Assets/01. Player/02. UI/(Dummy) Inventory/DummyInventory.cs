using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//public class Inventory : MonoBehaviour
//{
//    public List<Item> items;                                // �������� ���� ����Ʈ
//    [SerializeField] private TrackedReference slotParent;   // ���� �̹���ó�� Slot�� �θ� �Ǵ� Bag�� ���� ��
//    [SerializeField] private Slot[] slots;                  // Bag�� ������ ��ϵ� Slot�� ���� ��
//
//    private void OnValidate()                               // OnValidate()�� ����� ����Ƽ �����Ϳ��� �ٷ� �۵��� �ϴ� ����
//    {
//        slots = GetComponentsInChildren<Slot>();            // ó�� �κ��丮�� �ҽ��� ����Ͻø� Consoleâ�� ������ ������ Bag�� �־� �ֽø� 
//                                                            // slots�� Slot���� �ڵ� ����� ��
//    }
//    private void Awake()
//    {
//        FreshSlot();                                        // ������ ���۵Ǹ� items�� ��� �ִ� �������� �κ��丮�� �־� �ݴϴ�.
//    }
//    public void FreshSlot()                                 // FreshSlot�� ������ �������� �����ų� ������ Slot�� ������ �ٽ� �����Ͽ� ȭ�鿡 ���� �ִ� ���
//    {
//        int i = 0;                                          // int i = 0�� �ܺο� ������ �� �� ���� For ���� ���� i�� ���� ����ϱ� ���ؼ��Դϴ�.
//        for (; i < items.Count && i < slots.Length; i++)    // ù for���� items�� ��� �ִ� ����ŭ slots�� ���ʴ�� item�� �־� �ݴϴ�.
//        {                                                   // "i < items.Count && i < slots.Length" i�� ���� items�� slots �� ���� �� ���� �۾ƾ߸� ���ư��� �����Դϴ�. items�� ���� slots ������ ������ �� �Ǳ� ������
//            slots[i].item = items[i];                       // slot�� item�� ���� Slot.cs�� ����� item�� set ���� ������ ����Ǿ� �ش� ���Կ� �̹����� ǥ���ϰ� �˴ϴ�
//        }
//        for (; i < slots.Length; i++)                       // �� ��° for���� �� �� i�� ���� ù ��° for������ ���ǰ� ���� ������ �����ϰ� �˴ϴ�. �� ���⼭ i�� ���� ������ �����̸�
//        {                                                   // �������� ���ʴ�� i��° ���Կ� �ְ� ������ i��° ������ null�� �־� �� �������� ǥ�õǰ� �մϴ�. 
//            slots[i].item = null;                           // slot�� �������� �� �����ϰ� �� �Ŀ��� slot�� ���� �ִٸ� ���� for���� ����Ǿ� �� ���Ե��� ��� null ó��
//        }
//    }
//    public void AddItem(Item _item)                         // �������� ȹ���� ��� AddItem�� �ҷ��� �־� �ֽø� �˴ϴ�.
//    {
//        if (items.Count < slots.Length)
//        {
//            items.Add(_item);
//            FreshSlot();
//        }
//        else
//        {
//            print("�� ������ �����ϴ�.");
//        }
//    }
//}
