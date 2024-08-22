using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrap : DoorManualStandard
{
    ParticleSystem ps;

    protected override void Awake()
    {
        base.Awake();
        Transform child = transform.GetChild(3);
        ps = child.GetComponent<ParticleSystem>();  // 파티클 시스템 찾기
    }

    protected override void OnOpen()
    {
        base.OnOpen();
        ps.Play();          // 파티클 시스템 재생

        StartCoroutine(AutoClose(ps.main.duration + ps.main.startLifetime.constantMax));    // 코루틴의 파라메터 = 메인 모듈의 재생기간 + 파이클 입자하나의 최대 수명
        GameManager.Instance.Player.Die();
    }

    IEnumerator AutoClose(float delay)
    {
        yield return new WaitForSeconds(delay); // 파티클이 다 사라질때까지 대기
        Close();
    }
}
