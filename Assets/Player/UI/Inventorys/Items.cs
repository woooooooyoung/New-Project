using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTape
{
    Equipement,     // 장비
    Consumables,    // 소모품
    Etc             // 기타
}
[System.Serializable]
public class Items
{
    public ItemTape ItemTape;   // 아이템 타입
    public string itemName;     // 아이템 이름
    public Sprite itemImage;    // 이아템 이미지
    public List<ItemEffect> efts;

    public bool Use() // 아이템 사용 성공여부 반환
    {
        // 아이템 사용
        bool isUsed = false;
        foreach (ItemEffect eft in efts)// Use매서드에서 반복문을 돌려 efts의 ExecuteRole를 실행
        {
            isUsed = eft.ExecuteRole();
        }
        return isUsed;
    }
}

