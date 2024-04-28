using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperUpgrade : Upgrade
{
    [SerializeField] private GameObject sniper;
    public override void Apply(PlayerPhysics player)
    {
        player.bullet = sniper;
        player.startTimeBtwShots = 0.65f;
    }
}
