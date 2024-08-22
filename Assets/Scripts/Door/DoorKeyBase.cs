using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyBase :DoorBase, IUnlockable
{
    /// <summary>
    /// 잠금해제 처리 함수
    /// </summary>
    public void UnLock()
    {
        Open();
    }
}
