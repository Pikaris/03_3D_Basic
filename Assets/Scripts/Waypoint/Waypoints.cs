using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    /// <summary>
    /// 모든 웨이포인트 지점들
    /// </summary>
    /// 
    Transform[] points;

    /// <summary>
    /// 현재 이동중인 웨이포인트 지점의 인덱스
    /// </summary>
    int index = 0;

    /// <summary>
    /// 현재 이동중인 웨이포인트 지점의 트랜스폼
    /// </summary>
    public Transform CurrtentWaypoint => points[index];

    private void Awake()
    {
        points = new Transform[transform.childCount];       // 자식 개수만큼 배열 만들기
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);              // 배열에 자식을 순서대로 채우기
        }
    }

    /// <summary>
    /// 다음 웨이포인트 지점을 리턴하고 index를 갱신하는 함수
    /// </summary>
    /// <returns>다음 웨이포인트 지점의 트랜스폼</returns>
    public Transform GetNextWaypoint()
    {
        index++;

        index %= points.Length;
        //if(index >= points.Length)
        //{
        //    index = 0;
        //}

        return points[index];
    }
}
