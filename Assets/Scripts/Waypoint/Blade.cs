using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : WaypointUserBase
{
    public float spinSpeed = 720.0f;
    Transform bladeMesh;

    protected override Transform Target
    {
        set
        {
            base.Target = value;
            transform.LookAt(Target);       // 다음 웨이포인트 지점이 설정될 때 방향이 전환된다.
        }
    }

    private void Awake()
    {
        bladeMesh = transform.GetChild(0);
    }

    private void Update()
    {
        bladeMesh.Rotate(Time.deltaTime * spinSpeed * Vector3.right);   // 날 메시는 따로 돌린다.
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();   // 플레이어가 닿으면 죽는다.
        player?.Die();
    }
}
