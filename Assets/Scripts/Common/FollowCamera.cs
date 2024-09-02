using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    /// <summary>
    /// 카메라가 따라다닐 대상의 트랜스폼
    /// </summary>
    public Transform target;

    /// <summary>
    /// 카메라 위치가 보간되는 정돈
    /// </summary>
    public float smooth = 3.0f;

    /// <summary>
    /// 플레이어와 카메라의 간격
    /// </summary>
    Vector3 offset;

    /// <summary>
    /// 플레이어와 카메라 사이의 거리(offset의 길이)
    /// </summary>
    float length;

    private void Start()
    {
        if(target == null)
        {
            Player player = GameManager.Instance.Player;
            target = player.transform.GetChild(8);
        }
        offset = transform.position - target.position;      // target에서 카메라로 가는 방향 벡터
        length = offset.magnitude;
    }

    //private void LateUpdate() // 물리와 일반 업데이트 차이 때문에 떨리는 현상이 발생한다.
    private void FixedUpdate()
    {
        // 대상 위치에서 회전된 offset만큼 떨어지기(회전 정도는 플레이어의 y축 회전 만큼)
        transform.position = Vector3.Slerp(transform.position, target.position + Quaternion.LookRotation(target.forward) * offset, Time.fixedDeltaTime * smooth);
        //transform.position = target.position + Quaternion.LookRotation(target.forward) * offset;    // 적절한 위치로 이동하기
        transform.LookAt(target);   // target 바라보게 만들기

        Ray ray = new Ray(target.position, transform.position - target.position);   // 카메라 root에서 카메라 방향으로 나가는 ray
        if(Physics.Raycast(ray, out RaycastHit hitInfo, length))
        {
            transform.position = hitInfo.point;     // 충돌한 위치로 즉시 옮기기
        }
;    }
}
