using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Auto : Platform_OneWay
{
    // 플레이어가 플랫폼 위에 올라오면 반대쪽으로 이동하는 플랫폼

    protected override void RiderOn(IPlatformRide target)
    {
        base.RiderOn(target);
        isPause = false;
    }
}
