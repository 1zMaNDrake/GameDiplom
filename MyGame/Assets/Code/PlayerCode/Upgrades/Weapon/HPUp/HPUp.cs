using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUp : Upgrade
{
    [SerializeField] private float _healthAmount;
    public override void Apply(PlayerPhysics player)
    {
        player.GetComponent<HealthController>().AddMaxHealth(_healthAmount);
    }
}
