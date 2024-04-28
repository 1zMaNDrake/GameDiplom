using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUpgrade : Upgrade
{
    [SerializeField] private RocketLauncher launcherPrefab;

    public override void Apply(PlayerPhysics player)
    {
        var rocket = Instantiate(launcherPrefab, player.transform.position, Quaternion.identity);
        rocket.transform.SetParent(player.transform, true);
    }
}
