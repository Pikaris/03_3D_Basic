using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStandard : TurretBase
{
    // 일정 주기별로 firePosition 위치에서 계속 총알을 발사한다.

    private void Start()
    {
        StartCoroutine(PeriodFire());
    }

    private void Update()
    {
    }
}
