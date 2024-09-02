using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_OneWay : PlatformBase
{
    /// <summary>
    /// 플랫폼 이동여부를 결정하는 변수(true면 정지, false면 이동)
    /// </summary>
    protected bool isPause = true;

    protected override void Start()
    {
        base.Start();
        Target = targetWaypoints.GetNextWaypoint();     // 시작했을 때 첫번째로 Point2로 이동하게끔 설정
    }

    protected override void OnMove(Vector3 moveDelta)
    {
        if (!isPause)
        {
            base.OnMove(moveDelta);
        }
    }

    protected override void OnArrived()
    {
        isPause = true;
        base.OnArrived();
    }
}
