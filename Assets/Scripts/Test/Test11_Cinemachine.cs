using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test11_Cinemachine : TestBase
{
    public CinemachineVirtualCamera[] vcams;

    CinemachineImpulseSource impulseSource;

    private void Start()
    {
        if(vcams.Length == 0)
        {
           vcams = FindObjectsByType<CinemachineVirtualCamera>(FindObjectsSortMode.None);
        }
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        vcams[0].Priority = 100;
        vcams[1].Priority = 10;
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        vcams[0].Priority = 10;
        vcams[1].Priority = 100;
    }

    protected override void OnTest3(InputAction.CallbackContext context)
    {
        impulseSource.GenerateImpulse();
    }

    protected override void OnTest4(InputAction.CallbackContext context)
    {
        Player player = FindAnyObjectByType<Player>();
        player.Die();
        //dollyCart.transform.position = player.transform.position;
    }
}
