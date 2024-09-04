using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MazeVisualizer))]
public class MazeBuilder : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public int seed = -1;

    MazeVisualizer visualizer;

    MazeBase maze;

    private void Awake()
    {
        visualizer = GetComponent<MazeVisualizer>();
    }

    /// <summary>
    /// 미로 만들고 그리는 함수
    /// </summary>
    public void Build()
    {
        maze = new WilsonMaze(width, height, seed); // 미로 만들고
        visualizer.Clear();
        visualizer.Draw(maze);                      // 미로 그리기
    }
}
