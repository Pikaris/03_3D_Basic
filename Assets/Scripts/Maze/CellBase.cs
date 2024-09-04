using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 미로의 한칸을 표시하는 클래스
/// </summary>
public class CellBase
{
    /// <summary>
    /// 이 셀에 있는 길을 기록하는 변수(북동남서 순서대로 비트 설정, 1로 설정되어 있으면)
    /// </summary>
    PathDirection path;

    /// <summary>
    /// 열린 길을 확인하기 위한 프로퍼티
    /// </summary>
    public PathDirection Path => path;

    /// <summary>
    /// 미로 그리드 상에서의 x좌표(왼쪽 -> 오른쪽)
    /// </summary>
    protected int x;

    /// <summary>
    /// 미로 그리드 상에서의 y좌표(위 -> 아래)
    /// </summary>
    protected int y;

    /// <summary>
    /// x좌표 확인용 프로퍼티
    /// </summary>
    public int X => x;

    /// <summary>
    /// y좌표 확인용 프로퍼티
    /// </summary>
    public int Y => y;
    
    /// <summary>
    /// x, y좌표를 받는 생성자
    /// </summary>
    /// <param name="x">x위치</param>
    /// <param name="y">y위치</param>
    public CellBase(int x, int y)
    {
        path = PathDirection.None;
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// 이 셀에 길을 새로 추가하는 함수
    /// </summary>
    /// <param name="newPath">새롭게 길이 열릴 방향</param>
    public void MakePath(PathDirection newPath)
    {
        path |= newPath;
    }

    /// <summary>
    /// 특정 방향이 길인지 확인하는 함수
    /// </summary>
    /// <param name="direction">확인할 방향</param>
    /// <returns>true면 길이다. false면 벽이다.</returns>
    public bool IsPath(PathDirection direction)
    {
        return (path & direction) != 0;
    }

    /// <summary>
    /// 특정 방향이 벽인지 확인하는 함수
    /// </summary>
    /// <param name="direction">확인할 방향</param>
    /// <returns>true면 벽이다. false면 길이다.</returns>
    public bool IsWall(PathDirection direction)
    {
        return (path & direction) == 0;
    }

    /// <summary>
    /// dir1, dir2가 코너를 이루는지 확인하는 함수
    /// </summary>
    /// <param name="dir1">확인할 방향1</param>
    /// <param name="dir2">확인할 방향2</param>
    /// <returns>dir1, dir2가 코너를 만드는 방향이고 둘 다 길이 있으면 true</returns>
    public bool CornerPathCheck(PathDirection dir1, PathDirection dir2)
    {
        bool result = false;
        PathDirection corner = dir1 | dir2;
        if(corner ==(PathDirection.North | PathDirection.West)
            || corner == (PathDirection.North | PathDirection.East)
            || corner == (PathDirection.South | PathDirection.East)
            || corner == (PathDirection.South | PathDirection.West))        // 4개 코너 중 하나인지 확인
        {
            result = IsPath(dir1) && IsPath(dir2);      // 두 방향 다 길이 있어야 한다.
        }

        return result;
    }
}
