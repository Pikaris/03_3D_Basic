using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test06_Doors : TestBase
{
    Transform cam1;
    Transform cam2;

    private void Start()
    {
        cam1 = transform.GetChild(0);
        cam2 = transform.GetChild(1);
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        Camera.main.transform.position = cam1.position;
        Camera.main.transform.rotation = cam1.rotation;
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        Camera.main.transform.position = cam2.position;
        Camera.main.transform.rotation = cam2.rotation;
    }
}
