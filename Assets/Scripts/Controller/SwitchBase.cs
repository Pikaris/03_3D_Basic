using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBase : MonoBehaviour, IInteractable
{
    // on 상태, off 상태
    // 사용하면 on/off가 번갈아가면서 설정된다
    // on 상태가 되었을 때 연결된 문이 열린다
    // off 상태가 되었을 때 연결된 문이 닫힌다

    /// <summary>
    /// 스위치 사용 쿨타임(최소값 0.5, 재생 애니메이션이 0.5초 짜리이기 때문에)
    /// </summary>
    [Min(0.5f)]
    public float coolTime = 0.5f;

    /// <summary>
    /// 이 스위치가 사용할 오브젝트
    /// </summary>
    public GameObject targetObject;

    /// <summary>
    /// targetObject가 상속받은 IInteractable
    /// </summary>
    IInteractable target;

    /// <summary>
    /// 현재 남아있는 쿨타임
    /// </summary>
    float remainCoolTime = 0.0f;

    /// <summary>
    /// 켜져있는지 꺼져있는지를 기록하는 변수(true면 켜짐, false면 꺼짐)
    /// </summary>
    bool isOn = false;

    /// <summary>
    /// 남은 쿨타임이 0이하면 사용 가능
    /// </summary>
    public bool CanUse => remainCoolTime < 0.0f;

    /// <summary>
    /// 켜지고 꺼지는 처리를 할 프로퍼티
    /// </summary>
    bool IsOn
    {
        get => isOn;
        set
        {
            isOn = value;
            if (target != null)
            {
                target.Use();
            }
            else
            {
                Debug.LogWarning("사용할 오브젝트가 없습니다.");
            }
            animator.SetBool(On_Hash, isOn);
        }
    }

    Animator animator;

    readonly int On_Hash = Animator.StringToHash("On");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (targetObject != null)
        {
            target = targetObject.GetComponent<IInteractable>();
        }
        else
        {
            Debug.LogWarning("사용할 오브젝트가 없습니다.");
        }
    }

    private void Update()
    {
        remainCoolTime -= Time.deltaTime;
    }

    public void Use()
    {
        if (CanUse)
        {
            IsOn = !IsOn;
            remainCoolTime = coolTime;
        }
    }
}

