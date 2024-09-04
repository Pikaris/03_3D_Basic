using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class VirtualButton : MonoBehaviour, IPointerClickHandler
{
    // 1. 누르면 플레이어가 점프한다.
    // 2. 플레이어 쿨다운 변화에 따라 CoolTime이미지의 Fill Amount가 변화한다.

    public Action<bool> onJumpInput;

    Image image;

    private void Awake()
    {
        Transform child = transform.GetChild(1);
        image = child.GetComponent<Image>();
    }

    private void Start()
    {
        Player player = GameManager.Instance.Player;
        if (player != null)
        {
            player.onJumpCoolTimeChange += (fillAmount) => Cool(fillAmount);
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        onJumpInput?.Invoke(true);
    }

    void Cool(float fillAmount)
    {
        fillAmount -= Time.deltaTime;
        image.fillAmount = fillAmount;
    }
}
