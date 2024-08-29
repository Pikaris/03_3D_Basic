using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Push : TrapBase
{
    // 바닥에 안보이던 판이 일어나면서 플레이어를 밀어낸다(애니메이터)

    /// <summary>
    /// 미는 힘의 정도
    /// </summary>
    public float pushPower = 5.0f;

    /// <summary>
    /// 미는 방향
    /// </summary>
    Vector3 pushDirection;

    Animator animator;
    readonly int Activate_Hash = Animator.StringToHash("Activate");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        pushDirection = (transform.forward + transform.up).normalized;      // 대각선 앞쪽위 방향
    }

    protected override void OnTrapActivate(GameObject target)
    {
        animator.SetTrigger(Activate_Hash);
        Rigidbody playerRigid = target.GetComponent<Rigidbody>();
        playerRigid?.AddForce(pushPower * pushDirection, ForceMode.Impulse);
    }
}
