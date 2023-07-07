using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 인터페이스의 기능은 아이템을 클릭 시 그 아이템이 가지고 있는 정보를 넘겨주는 역할
public interface IObjectItem
{
    Item ClickItem();
}
