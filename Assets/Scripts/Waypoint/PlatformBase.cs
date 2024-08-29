using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBar : WaypointUserBase
{
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
}
