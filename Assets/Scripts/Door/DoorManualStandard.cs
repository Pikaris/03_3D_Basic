using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class DoorManualStandard : DoorManualBase, IInteractable
{
    /// <summary>
    /// 재사용에 필요한 쿨타임
    /// </summary>
    public float coolTime = 1.0f; 
    
    /// <summary>
    /// 현재 남아있는 쿨타임
    /// </summary>
    float remainCoolTime = 0.0f;

    /// <summary>
    /// 근처에 플레이어가 접근하면 상호작용용 단축키를 알려주는 3D 텍스트
    /// </summary>
    TextMeshPro text;

    /// <summary>
    /// 현재 이 오브젝트를 사용가능한지 판단하기 위한 프로퍼티(인터페이스에 있는 프로퍼티 구현)
    /// </summary>
    public override bool CanUse => remainCoolTime < 0.0f;

    protected override void Awake()
    {
        base.Awake();
        text = GetComponentInChildren<TextMeshPro>(true);
    }

    private void Update()
    {
        remainCoolTime -= Time.deltaTime;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ShowInfoPanel(true);
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ShowInfoPanel(false);
        }
    }

    /// <summary>
    /// 문을 사용하는 함수(인터페이스에 있는 함수 구현)
    /// </summary>
    public override void Use()
    {
        if(CanUse)
        {
            base.Use();

            remainCoolTime = coolTime;
        }
    }

    private void ShowInfoPanel(bool isShow = true)
    {
        if (isShow)
        {
            // 카메라에서 문으로 가는 방향 벡터
            Vector3 cameraToDoor = transform.position - Camera.main.transform.position;

            float angle = Vector3.Angle(transform.forward, cameraToDoor);
            if (angle > 90.0f)
            {
                // 카메라가 문 앞쪽에 있다.
                text.transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
            }
            else
            {
                // 카메라가 문 뒤쪽에 있다.
                text.transform.rotation = transform.rotation;   // 인포의 회전을 문의 회전과 일치시킨다
            }
        }

        text.gameObject.SetActive(isShow);
    }
}
