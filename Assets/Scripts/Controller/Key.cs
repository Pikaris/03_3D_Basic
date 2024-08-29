using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Key : MonoBehaviour
{
    /// <summary>
    /// 이 열쇠가 열 문
    /// </summary>
    public DoorBase targetDoor;

    /// <summary>
    /// 문의 잠금해제 인터페이스
    /// </summary>
    IUnlockable unlockable;

    /// <summary>
    /// 메시 모델의 트랜스폼
    /// </summary>
    Transform model;

    private void Awake()
    {
        model = GetComponent<Transform>();  // 회전시킬 메시 찾기

        // as : as왼쪽에 있는 변수가 as 오른쪽에 있는 타입으로 변경이 가능하면 null이 아닌 값, 변경이 불가능하면 null
        unlockable = targetDoor as IUnlockable;

        if (unlockable == null)     // 잠금해제 가능한 문이 아니면
        {
            Debug.LogWarning($"잠금해제가 불가능한 문입니다 : {targetDoor}");
            targetDoor = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))     // 플레이어가 먹었을 때
        {
            if(targetDoor != null)
            {
                unlockable.UnLock();        // 잠금 해제가능한 문이 등록되어 있으면 잠금해제(무조건 등록되어 있어야 함)
            }
            else
            {
                Debug.LogWarning("잠금해제 할 문이 없습니다");     // 없으면 경고 출력
            }
            gameObject.SetActive(false);    // 먹은 열쇠는 사라지기
        }
    }
}
