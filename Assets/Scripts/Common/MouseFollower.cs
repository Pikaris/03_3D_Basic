using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    TestInputActions inputActions;

    private void Awake()
    {
        inputActions = new TestInputActions();
    }

    private void OnEnable()
    {
        inputActions.Test.Enable();
        //inputActions.Test.PointerMove.performed += OnPointerMove;
    }

    private void OnDisable()
    {
        //inputActions.Test.PointerMove.performed -= OnPointerMove;
        inputActions.Test.Disable();
    }

    void OnPointerMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Vector3 mousePos = context.ReadValue<Vector2>();        // 마우스 커서의 스크린좌표
        mousePos.z = transform.position.z - Camera.main.transform.position.z;   // 카메라 위치만큼 떨어트리기

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);        // 스크린좌표를 월드 좌표로 변경
        transform.position = worldPos;
    }
}
