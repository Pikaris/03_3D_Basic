using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    /// <summary>
    /// 바닥에 닿았음을 알리는 델리게이트(bool : true면 바닥에 닿았다, false면 공중이다)
    /// </summary>
    public Action<bool> onGround;

    /// <summary>
    /// 트리거에 여러 오브젝트가 닿았을 때를 대비하기 위한 변수
    /// </summary>
    int groundCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        groundCount++;
        if (groundCount > 0)
        {
            onGround?.Invoke(true);     // 트리거에 하나 이상의 물체가 들어오면 true로 알림
        }
    }

    private void OnTriggerExit(Collider other)
    {
        groundCount--;
        if (groundCount < 1)
        {
            onGround?.Invoke(false);    // 트리거에 들어있는 물체가 없을 때 false로 알림
            groundCount = 0;
        }
    }
}
