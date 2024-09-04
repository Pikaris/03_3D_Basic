using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBase
{
    /// <summary>
    /// 미로의 가로 길이
    /// </summary>
    protected int width;

    /// <summary>
    /// 미로의 세로 길이
    /// </summary>
    protected int height;

    /// <summary>
    /// 미로의 가로 길이 확인용 프로퍼티
    /// </summary>
    public int Width => width;

    /// <summary>
    /// 미로의 세로 길이 확인용 프로퍼티
    /// </summary>
    public int Height => height;

    /// <summary>
    /// 미로를 구성하고 있는 셀들
    /// </summary>
    protected CellBase[] cells;

    /// <summary>
    /// 모든 셀을 확인하기 위한 프로퍼티
    /// </summary>
    public CellBase[] Cells => cells;

    /// <summary>
    /// 미로 생성자
    /// </summary>
    /// <param name="width">가로 길이</param>
    /// <param name="height">세로 길이</param>
    /// <param name="seed">이 미로의 시드값(-1이면 유니티 기본설정대로, 아니면 지정된 값을 새 시드로 설정</param>
    /// <param name=""></param>
    public MazeBase(int width, int height, int seed = -1)
    {
        this.width = width;
        this.height = height;

        if(seed != -1)
        {
            Random.InitState(seed);
        }

        cells = new CellBase[width * height];   // 배열 생성
            
        OnSpecificAlgorithmExcute();            // 미로 알고리즘 실행
    }

    /// <summary>
    /// 각 알고리즘별로 override해서 사용할 함수, 알고리즘별 구현 코드 입력 필요(빈함수)
    /// </summary>
    protected virtual void OnSpecificAlgorithmExcute()
    {
        // cell 생성하고 알고리즘 결과에 맞게 세팅
    }

    /// <summary>
    /// from셀과 to셀 사이를 지날 수 있는 경로 만들기
    /// </summary>
    /// <param name="from">시작 셀</param>
    /// <param name="to">도착 셀</param>
    protected void ConnectPath(CellBase from, CellBase to)
    {
        Vector2Int dir = new(to.X - from.X, to.Y - from.Y);     // from에서 to로 가는 방향 구하기
        if (dir.x > 0)
        {
            // (1,0) 동쪽
            from.MakePath(PathDirection.East);
            to.MakePath(PathDirection.West);
        }
        else if (dir.x < 0)
        {
            // (-1,0) 서쪽
            from.MakePath(PathDirection.West);
            to.MakePath(PathDirection.East);
        }
        else if (dir.y > 0)
        {
            // (0,1) 남쪽
            from.MakePath(PathDirection.South);
            to.MakePath(PathDirection.North);
        }
        else if (dir.y < 0)
        {
            // (0,-1) 북쪽
            from.MakePath(PathDirection.North);
            to.MakePath(PathDirection.South);
        }
    }

    /// <summary>
    /// 미로 범위 안인지 밖인지 확인하는 함수
    /// </summary>
    /// <param name="x">확인할 x 그리드 좌표</param>
    /// <param name="y">확인할 y 그리드 좌표</param>
    /// <returns>true 면 미로 그리드 안, false면 밖</returns>
    protected bool IsInGrid(int x, int y)
    {
        return x >= 0 && y >= 0 && x < width && y < height;
    }

    /// <summary>
    /// 미로 범위 안인지 밖인지 확인하는 함수
    /// </summary>
    /// <param name="grid">확인할 그리드 좌표</param>
    /// <returns>true면 미로 그리드 안, false면 밖</returns>
    protected bool IsInGrid(Vector2Int grid)
    {
        return IsInGrid(grid.x, grid.y);
    }

    /// <summary>
    /// cells 배열의 인덱스 값을 그리드 값으로 변환해 주는 함수
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    protected Vector2Int IndexTroGrid(int index)
    {
        return new Vector2Int(index % width, index / width);
    }

    /// <summary>
    /// 그리드 좌표를 인덱스로 변환하는 함수
    /// </summary>
    /// <param name="x">변환할 x 그리드 좌표</param>
    /// <param name="y">변환할 y 그리드 좌표</param>
    /// <returns>cells 배열의 인덱스</returns>
    protected int GridToIndex(int x, int y)
    {
        return x + y * width;
    }

    /// <summary>
    /// 그리드 좌표를 인덱스로 변환하는 함수
    /// </summary>
    /// <param name="grid">변환할 그리드 좌표</param>
    /// <returns>cells 배열의 인덱스</returns>
    protected int GridToIndex(Vector2Int grid)
    {
        return GridToIndex(grid.x, grid.y);
    }

    /// <summary>
    /// 특정 그리드 좌표에 있는 셀을 리턴해주는 함수
    /// </summary>
    /// <param name="x">x좌표</param>
    /// <param name="y">y좌표</param>
    /// <returns>(x,y)위치에 있는 셀</returns>
    public CellBase GetCell(int x, int y)
    {
        CellBase cell = null;
        if(IsInGrid(x, y))      // 미로 영역안에 포함되는 경우만 처리
        {
            cell = cells[GridToIndex(x, y)];
        }
        return cell;
    }
}
