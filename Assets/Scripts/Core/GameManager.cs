using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// 플레이어
    /// </summary>
    Player player;

    /// <summary>
    /// 플레이어 확인용 프로퍼티
    /// </summary>
    public Player Player => player;

    /// <summary>
    /// 가상 스틱
    /// </summary>
    VirtualStick stick;

    /// <summary>
    /// 가상 스틱 확인용 프로퍼티
    /// </summary>
    public VirtualStick Stick => stick;

    VirtualButton button;

    public VirtualButton Button => button;

    /// <summary>
    /// 초기화용 함수
    /// </summary>
    protected override void OnInitialize()
    {
        player = FindAnyObjectByType<Player>();
        stick = FindAnyObjectByType<VirtualStick>();
        button = FindAnyObjectByType<VirtualButton>();
    }
}

