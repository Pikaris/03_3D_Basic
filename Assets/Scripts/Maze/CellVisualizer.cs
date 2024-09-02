using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellVisualizer : MonoBehaviour
{
    /// <summary>
    /// 셀 한변의 길이를 나타내는 상수
    /// </summary>
    public const float CellSize = 10.0f;

    /// <summary>
    /// 벽 게임 오브젝트의 배열
    /// </summary>
    GameObject[] walls;

    /// <summary>
    /// 코너 게임 오브젝트의 배열
    /// </summary>
    GameObject[] corners;

    private void Awake()
    {
        Transform child = transform.GetChild(1);    // 벽의 부모

        walls = new GameObject[child.childCount];   // 벽 배열 만들고 저장하기
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i] = child.GetChild(i).gameObject;
        }

        child = transform.GetChild(2);                  // 코너의 부모
        corners = new GameObject[child.childCount];     // 코너 배열 만들고 저장하기
        for (int i = 0; i < corners.Length; i++)
        {
            corners[i] = child.GetChild(i).gameObject;
        }
    }

    /// <summary>
    /// 입력 받은 데이터에 맞게 벽의 활성화 여부 재설정
    /// </summary>
    /// <param name="data">벽의 on/off를 표시하는 비트마스크</param>
    public void RefreshWall(PathDirection flagData)
    {
        // data : 북동남서 순서대로 1이 세팅되어 있으면 길(= 벽이 없음), 0이 세팅되어 있으면 벽.
        // 0000 ~ 1111
        // 0001 : 북쪽에만 길이 있고 동남서는 벽이다
        // 0110 : 동쪽과 남쪽에는 길이 있고 북쪽과 서쪽은 벽이다.

        int data = (int)flagData;

        for (int i = 0; i < walls.Length; i++)
        {
            int mask = 1 << i;     // 0001, 0010, 0100, 1000
            walls[i].SetActive((data & mask) == 0); // & 결과가 0이면 mask에 세팅 된 비트자리가 0이었다는 소리이므로 벽이 있어야 한다.
        }
    }

    /// <summary>
    /// 입력 받은 데이터에 맞게 코너의 활성화 여부 재설정
    /// </summary>
    /// <param name="data">코너의 on/off를 표시하는 비트마스크</param>
    public void RefreshCorner(CornerMask flagData)
    {
        int data = (int)flagData;

        for (int i = 0; i < walls.Length; i++)
        {
            int mask = 1 << i;     // 0001, 0010, 0100, 1000
            corners[i].SetActive((data & mask) != 0); // & 결과가 0이면 mask에 세팅 된 비트자리가 0이었다는 소리이므로 z코너가 없어야 한다.
        }
    }


    //public PathDirection Getpath()
    //{
    //    int mask = 0;

    //    for(int i = 0; i < walls.Length; i++)
    //    {
    //        if(!walls[i].activeSelf)    // 벽이 비활성화 되어 있으면(길이 나있다)
    //        {
    //            mask |= 1 << i;         // 해당 비트에 1 세팅
    //        }
    //    }

    //    return (PathDirection)mask;
    //}
}
