using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBullets : Upgrade
{
    public override void Apply(PlayerPhysics player)
    {
        player.bulletCount += 1;
    }
}

