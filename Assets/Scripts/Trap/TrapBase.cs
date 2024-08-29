using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))     // 플레이어가 밟으면 함정 발동
        {
            OnTrapActivate(other.gameObject);
        }
    }

    /// <summary>
    /// 함정이 발동되면 각 클래스 별로 실행할 동작을 정의할 가상함수(빈 함수)
    /// </summary>
    /// <param name="target">함정을 밟은 게임 오브젝트(플레이어)</param>
    protected virtual void OnTrapActivate(GameObject target)
    {

    }
}
