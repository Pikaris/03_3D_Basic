using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBase : WaypointUserBase
{
    /// <summary>
    /// 플랫폼이 움직일 때마다 움직인 정도를 파라메터로 넘기는 델리게이트
    /// </summary>
    Action<Vector3> onPlatformMove;

    protected override void Start()
    {
        if (targetWaypoints == null)
        {
            int nextIndex = transform.GetSiblingIndex() + 1;                    // 동생의 인덱스 구하기
            Transform nextSibling = transform.parent.GetChild(nextIndex);       // 동생의 트랜스폼 구하기
            targetWaypoints = nextSibling.GetComponent<Waypoints>();            // 동생이 무조건 Waypoint를 가지고 있다는 전제
        }
        base.Start();
    }

    /// <summary>
    /// 이동 처리 + 이동 알림
    /// </summary>
    /// <param name="moveDelta">움직인 정도</param>
    protected override void OnMove(Vector3 moveDelta)
    {
        base.OnMove(moveDelta);
        onPlatformMove?.Invoke(moveDelta);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"OnTrigger : {other.gameObject.name}");
        IPlatformRide target = other.GetComponent<IPlatformRide>();
        if (target != null)     // 플랫폼을 탈 수 있는 오브젝트일 때
        {
            RiderOn(target);
            //Debug.Log($"등록 : {other.gameObject.name}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IPlatformRide target = other.GetComponent<IPlatformRide>();
        if (target != null)
        {
            RiderOff(target);
        }
    }

    /// <summary>
    /// 플랫폼 위에 타겟이 올라왔을 때 실행되는 함수
    /// </summary>
    /// <param name="target">플랫폼 위에 탄 대상</param>
    protected virtual void RiderOn(IPlatformRide target)
    {
        onPlatformMove += target.OnRidePlatform;    // 따라 움직이는 함수를 등록한다.
    }

    /// <summary>
    /// 플랫폼 위에 있던 타켓이 내려왔을 때 실행되는 함수
    /// </summary>
    /// <param name="target">플랫폼에서 내린 대상</param>
    protected virtual void RiderOff(IPlatformRide target)
    {
        onPlatformMove -= target.OnRidePlatform;
    }
}
