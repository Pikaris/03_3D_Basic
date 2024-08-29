using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyUnlock : DoorManualStandard, IUnlockable
{
    /// <summary>
    /// 잠겼는지 열렸는지 여부(true면 열렸다, false면 잠겨있다)
    /// </summary>
    bool unlocked = false;


    /// <summary>
    /// 현재 이 오브젝트를 사용가능한지 판단하기 위한 프로퍼티(인터페이스에 있는 프로퍼티 구현)
    /// </summary>
    public override bool CanUse => base.CanUse && unlocked;

    /// <summary>
    /// 잠금해제 처리하는 함수
    /// </summary>
    public void UnLock()
    {
        unlocked = true;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (unlocked)   // 잠금이 해제되었을 때만 단축키 표시 띄우기
        {
            base.OnTriggerEnter(other);
        }
    }
}
