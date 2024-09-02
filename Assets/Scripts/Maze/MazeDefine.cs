using System;

/// <summary>
/// Cell에 어느쪽으로 길이 나있는지 표시하기 위한 bitFlag용 enum
/// </summary>
[Flags]
public enum PathDirection : byte
{
    None = 0,   // 0000 0000
    North = 1,  // 0000 0001
    East = 2,   // 0000 0010
    South = 4,  // 0000 0100
    West = 8,   // 0000 1000
}

/// <summary>
/// Call의 코너
/// </summary>
[Flags]
public enum CornerMask : byte
{
    None = 0,
    NorthWest = 1,
    NorthEast = 2,
    SouthEast = 4,
    SouthWest = 8
}

public enum TestDirection : byte
{
    None = 0,   // 0000 0000
    North = 1,  // 0000 0001
    East = 2,   // 0000 0010
    South = 4,  // 0000 0100
    West = 8,   // 0000 1000
}
