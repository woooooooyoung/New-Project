using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 체력 회복아이템에 관한 이펙트
[CreateAssetMenu(menuName = "ItemEft/Consumable/Health")]
public class ItemHealingEft : ItemEffect
{
    public int healingPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("PlayerHp Add : " + healingPoint);
        return true;
    }
}
