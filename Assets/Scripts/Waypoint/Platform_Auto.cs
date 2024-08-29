using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Auto : PlatformBase
{
    // 플레이어가 플랫폼 위에 올라오면 반대쪽으로 이동하는 플랫폼

    /// <summary>
    /// 플레이어가 플랫폼에 올라왔는지(true면 올라옴, false면 안올라옴)
    /// </summary>
    bool onPlayer = false;

    /// <summary>
    /// 플랫폼 이동여부를 결정하는 변수(true면 정지, false면 이동)
    /// </summary>
    bool isPause = true;

    protected override void Start()
    {
        base.Start();
        Target = targetWaypoints.GetNextWaypoint();     // 시작했을 때 첫번째로 Point2로 이동하게끔 설정
    }

    protected override void OnMove(Vector3 moveDelta)
    {
        //if (onPlayer || !IsArrived)
        //{
        //    base.OnMove(moveDelta);
        //    onPlatformMove?.Invoke(moveDelta);
        //}
        if(!isPause)
        {
            base.OnMove(moveDelta);
        }
    }

    protected override void RiderOn(IPlatformRide target)
    {
        base.RiderOn(target);
        isPause = false;
    }

    protected override void RiderOff(IPlatformRide target)
    {
        base.RiderOff(target);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    onPlayer = true;
    //    //Debug.Log($"OnTrigger : {other.gameObject.name}");
    //    IPlatformRide target = other.GetComponent<IPlatformRide>();
    //    if (target != null)     // 플랫폼을 탈 수 있는 오브젝트일 때
    //    {
    //        //Debug.Log($"등록 : {other.gameObject.name}");
    //        onPlatformMove += target.OnRidePlatform;    // 따라 움직이는 함수를 등록한다.
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    onPlayer = false;
    //    IPlatformRide target = other.GetComponent<IPlatformRide>();
    //    if (target != null)
    //    {
    //        onPlatformMove -= target.OnRidePlatform;
    //    }
    //}

    protected override void OnArrived()
    {
        isPause = true;
        base.OnArrived();
        //if(IsArrived && onPlayer)
        //{
        //    base.OnArrived();
        //}
    }

    //protected override bool IsArrived => base.IsArrived;
}
