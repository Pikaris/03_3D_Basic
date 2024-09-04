using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilsonCell : CellBase
{
    /// <summary>
    /// 경로를 저장하기 
    /// </summary>
    public WilsonCell next;

    /// <summary>
    /// 미로에 포함된 셀인지 확인하고 설정하기 위한 함수
    /// </summary>
    public bool isMazeMember;

    public WilsonCell(int x, int y) : base(x, y)
    {
        next = null;
        isMazeMember = false;
    }
}
