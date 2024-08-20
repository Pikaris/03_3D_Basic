using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
    public GameObject bulletPrefab;

    /// <summary>
    /// 총알 발사 간격
    /// </summary>
    public float fireInterval = 1.0f;

    /// <summary>
    /// 총알 발사 위치 및 방향용 트랜스폼
    /// </summary>
    protected Transform fireTransform;

    /// <summary>
    /// 총의 트랜스폼
    /// </summary>
    protected Transform gunTransform;

    protected virtual void Awake()
    {
        gunTransform = transform.GetChild(2);
        fireTransform = gunTransform.GetChild(2);
    }

    /// <summary>
    /// 주기적으로 총알을 발사하는 코루틴
    /// </summary>
    /// <returns></returns>
    protected IEnumerator PeriodFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireInterval);
            Factory.Instance.GetBullet(fireTransform.position, fireTransform.eulerAngles);
        }
    }

#if UNITY_EDITOR
    protected virtual void OnDrawGizmos()
    {
        // 앞쪽 방향으로 빨간색 화살표 그리기
        Vector3 p0 = transform.position + transform.up * 0.01f;
        Vector3 p1 = p0 + transform.forward * 3.0f;
        Vector3 p2 = p1 + Quaternion.AngleAxis(150.0f, transform.up) * transform.forward * 0.2f;
        Vector3 p3 = p1 + Quaternion.AngleAxis(-150.0f, transform.up) * transform.forward * 0.2f;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(p0, p1);
        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p1, p3);
    }
#endif
}
