using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템의 사용효과 이펙트
public abstract class ItemEffect : ScriptableObject
{
    public abstract bool ExecuteRole();
    
}
