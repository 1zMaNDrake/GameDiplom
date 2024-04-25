using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Upgrade
{
    public override void Apply(PlayerPhysics player)
    {
        Debug.Log("test!!!");
    }
}
