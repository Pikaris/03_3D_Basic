using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DoorManualBase : DoorBase, IInteractable
{
    /// <summary>
    /// 문이 열려있는지를 표시하는 변수(true면 열려있다. false면 닫혀있다.)
    /// </summary>
    bool isOpen = false;

    /// <summary>
    /// 인터페이스 떄문에 일단 생성
    /// </summary>
    public virtual bool CanUse => true;

    /// <summary>
    /// 문을 사용하는 함수(인터페이스에 있는 함수 구현)
    /// </summary>
    public virtual void Use()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    /// <summary>
    /// 문이 열렸음을 표시하는 기능
    /// </summary>
    protected override void OnOpen()
    {
        isOpen = true;
    }

    /// <summary>
    /// 문이 닫혔음을 표시하는 기능
    /// </summary>
    protected override void OnClose()
    {
        isOpen = false;
    }

}
