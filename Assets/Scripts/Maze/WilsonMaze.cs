using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WilsonMaze : MazeBase
{
    /// <summary>
    /// 이웃의 방향들을 저장해놓은 변수
    /// </summary>
    readonly Vector2Int[] dirs = { new(0, 1), new(0, -1), new(-1, 0), new(1, 0) };
    public WilsonMaze(int width, int height, int seed) : base(width, height, seed)
    {

    }

    protected override void OnSpecificAlgorithmExcute()
    {
        // 1. 필드의 한 곳을 랜덤으로 미로에 추가한다
        // 2. 미로에 포함되지 않은 셀 중 하나를 랜덤으로 선택한다.(A셀)
        // 3. A셀 위치에서 랜덤으로 한칸 씩 움직인다.(움직인 경로는 기록되어야 한다.)
        // 4. 미로에 포함된 셀에 도착할 때 까지 3번을 반복한다.
        // 5. A셀 위치에서 미로에 포함된 영역에 도착할 때까지의 경로를 미로에 포함시킨다.(경로에 따라 벽을 제거한다)
        // 6. 모든 셀이 미로에 포함될 때까지 2번으로 돌아가 반복한다.
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                cells[GridToIndex(x, y)] = new WilsonCell(x, y);
            }
        }

        // 미로에 포함되지 않은 셀의 리스트 만들기(+랜덤으로 순서 섞기)
        int[] notInMazeArray = new int[cells.Length];       // 미로에 포함되지 않은 셀의 인덱스를 저장할 배열
        for(int i = 0; i < notInMazeArray.Length; i++)
        {
            notInMazeArray[i] = i;      // 인덱스 전부 기록
        }
        Util.Shuffle(notInMazeArray);   // 순서 섞고
                

        List<int> notInMaze = new List<int>(notInMazeArray);        // 섞인 배열을 기반으로 리스트 생성

        // 1. 필드의 한 곳을 랜덤으로 미로에 추가한다
        int firstIndex = notInMaze[0];      // 리스트의 첫번째 노드 값 저장하기
        notInMaze.RemoveAt(0);              // 리스트의 첫번째 노드 제거하기

        WilsonCell first = (WilsonCell)cells[firstIndex];   // 리스트의 첫번째 노드 값을 기준으로 셀 선택
        first.isMazeMember = true;          // 꺼낸 셀을 미로에 포함시키기

        while (notInMaze.Count > 0)
        {
            // 2. 미로에 포함되지 않은 셀 중 하나를 랜덤으로 선택한다.(A셀)
            int index = notInMaze[0];
            notInMaze.RemoveAt(0);
            WilsonCell current = (WilsonCell)cells[index];      // 첫번째 current 지정

            // 3. A셀 위치에서 랜덤으로 한칸 씩 움직인다.(움직인 경로는 기록되어야 한다.)

            // 4. 미로에 포함된 셀에 도착할 때 까지 3번을 반복한다.
            while (!current.isMazeMember)
            {
                WilsonCell neighbor = (WilsonCell)GetNeighbor(current);     // 이웃 구하고
                current.next = neighbor;        // 경로 저장하고
                current = neighbor;             // 이웃을 새 current로 지정
            }

            // 5. A셀 위치에서 미로에 포함된 영역에 도착할 때까지의 경로를 미로에 포함시킨다.(경로에 따라 벽을 제거한다)
            WilsonCell path = (WilsonCell)cells[index];
            while (path != current)
            {
                path.isMazeMember = true;                           // 이 셀을 미로에 포함시키기
                notInMaze.Remove(GridToIndex(path.X, path.Y));      // 미로에 포함되지 않은 셀 목록에서 제거
                ConnectPath(path, path.next);                       // 이 셀과 다음 셀 사이에 길만들기
                path = path.next;                                   // 다음 노드로 넘어가기
            }
        }   // 6. 모든 셀이 미로에 포함될 때까지 2번으로 돌아가 반복한다.

    }

    /// <summary>
    /// 파라메터로 받은 셀의 이웃 중 하나를 리턴하는 함수
    /// </summary>
    /// <param name="cell"></param>
    /// <returns></returns>
    CellBase GetNeighbor(CellBase cell)
    {
        Vector2Int neighborPos;

        do
        {
            Vector2Int dir = dirs[Random.Range(0, dirs.Length)];
            neighborPos = new(cell.X + dir.x, cell.Y + dir.y);
        } while (!IsInGrid(neighborPos));   // 그리드 영역 안이 선택될 때까지 반복

        return Cells[GridToIndex(neighborPos)];
    }
}
