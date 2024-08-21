using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSensor : MonoBehaviour
{
    /// <summary>
    /// 사용 가능한 오브젝트를 사용 시도했다는 신호
    /// </summary>
    public Action<IInteractable> onUse;

    private void OnTriggerEnter(Collider other)
    {
        //부모중에 IInteractable  인터페이스를 상속받은 클래스가 있으면
        IInteractable usable = other.GetComponentInParent<IInteractable>();

        if (usable != null)
        {
            onUse?.Invoke(usable);  // 신호 보내기
        }
    }
}
