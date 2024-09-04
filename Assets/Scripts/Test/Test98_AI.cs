using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Test98_AI : TestBase
{
    public NavMeshSurface surface;
    public NavMeshAgent agent;

    AsyncOperation navAsync;

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        StartCoroutine(UpdateSurface());
    }

    IEnumerator UpdateSurface()
    {
        navAsync = surface.UpdateNavMesh(surface.navMeshData);
        while(!navAsync.isDone)     // 비동기 명령이 끝날 때까지 반복
        {
            Debug.Log(navAsync.progress);
            yield return null;      // 한 프레임 대기
        }
        Debug.Log("NavMesh업데이트 완료");
    }

    protected override void OnTestLClick(InputAction.CallbackContext context)
    {
        Vector2 screen = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(screen);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, 1000, LayerMask.GetMask("Ground")))
        {
            agent.SetDestination(hitInfo.point);
        }
    }

    protected override void OnTest2(InputAction.CallbackContext context)
    {
        //agent.remainingDistance;    // 목적지까지 남아있는 거리
        //agent.pathPending;          // 길찾기 계산이 끝났는지 아닌지 알려주는 프로퍼티(계산 중이면 true)
    }
}
