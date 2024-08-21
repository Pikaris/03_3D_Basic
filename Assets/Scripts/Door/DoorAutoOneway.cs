using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAutoOneway : DoorAuto
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // 플레이어에서 문으로 향하는 방향 벡터
            Vector3 playerToDoor = transform.position - other.transform.position;

            float angle = Vector3.Angle(transform.forward, playerToDoor);   // 0~180사이로 결과가 나온다
            if(angle > 90.0f)
            {
                Open(); // 사이각이 90도보다 크면 플레이어가 문의 앞쪽에 있다. 그때만 문을 연다.
            }
        }
    }
}
