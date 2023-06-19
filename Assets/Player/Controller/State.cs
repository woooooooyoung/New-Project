using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public enum States { Idle, Attack, Die, Kill, Chase}
    private States state = States.Idle;

    private void Update()
    {
        //switch (state)
        //{
        //    case States.Idle:
        //        ChaseUpdate();
        //        break;
        //    case States.Attack:
        //        
        //}
    }

    private void IdleUpdate()
    {
        
    }
    private void ChaseUpdate()
    {
        // 추격
        // 범위안에 들어오면 공격
        // 완벽히 놓치면 Idle로 돌아가기
    }
}
