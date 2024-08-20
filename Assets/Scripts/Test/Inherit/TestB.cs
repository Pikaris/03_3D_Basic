using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestB : TestA
{
    public override void RunVirtual()
    {
        Debug.Log("Run override B");
    }
}
