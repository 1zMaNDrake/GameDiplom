using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private PlayerShoot playerShoot;
    private Upgrades[] upgrades;

    public void ChangeWeaponForPlayer()
    {
        upgrades = new Upgrades[2];
        upgrades = Resources.LoadAll<Upgrades>("Upgrades/");
        playerShoot.upgrade = upgrades[1];
        Debug.Log("Вы поменяли пули на снайперские");
    }
}
