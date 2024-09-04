using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualStick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    /// <summary>
    /// 핸들의 rect
    /// </summary>
    RectTransform handle;

    /// <summary>
    /// 핸들이 움직일 배경의 rect
    /// </summary>
    RectTransform background;

    /// <summary>
    /// 가상 스틱이 움직일 수 있는 최대 거리
    /// </summary>
    float stickRange;

    /// <summary>
    /// 이동 입력이 있었음을 알리는 델리게이트
    /// </summary>
    public Action<Vector2> onMoveInput;

    private void Awake()
    {
        background = transform as RectTransform;

        Transform child = transform.GetChild(0);
        handle = child as RectTransform;

        stickRange = (background.rect.width - handle.rect.width) * 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,                     // background 영역의 원점 기준으로
            eventData.position,             // 이 스크린 좌표가
            eventData.pressEventCamera,     // (이 카메라 기준으로)
            out Vector2 localMove);         // 이만큼 움직였다(로컬좌표)

        // 핸들은 배경영역을 벗어나지 않아야 한다.
        localMove = Vector2.ClampMagnitude(localMove, stickRange);      // 핸들은 배경영역을 벗어나지 않게하기

        InputUpdate(localMove);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그가 끝났을 때 핸들은 중립위치(첫 위치)로 돌아가야 한다.
        InputUpdate(Vector2.zero);
    }

    /// <summary>
    /// 핸들 입력 관련을 실제로 처리하는 함수
    /// </summary>
    /// <param name="inputDelta">핸들이 움직인 정도</param>
    void InputUpdate(Vector2 inputDelta)
    {
        // 움직임 처리
        handle.anchoredPosition = inputDelta;

        onMoveInput?.Invoke(inputDelta/stickRange);     // 크기를 0~1 사이로 정규화해서 보냄
    }

    /// <summary>
    /// 가상 패드와의 모든 연결을 끊는 함수
    /// </summary>
    public void Disconnect()
    {
        onMoveInput = null;
    }
}
