using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradesUIManager : MonoBehaviour
{
    [SerializeField] private UpgradeUI upgradeUIPrefab;
    [SerializeField] private UpgradesManager upgradeManager;

    public void ShowUpgrades(List<Upgrade> upgrades, PlayerPhysics player)
    {
        gameObject.SetActive(true);

        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        int i = 0;
        System.Random rnd = new();
        upgrades = upgrades.OrderBy(x => rnd.Next()).ToList();

        foreach (var upgrade in upgrades)
        {
            i++;
            if (i == 4)
                break;
            var ui = Instantiate(upgradeUIPrefab, transform);
            ui.Setup(upgrade.title, upgrade.icon, upgrade.description, () => OnCLickApply(upgrade, player));
        }
    }


    public void HideUpgrades()
    {
        gameObject.SetActive(false);
    }

    void OnCLickApply(Upgrade upgrade, PlayerPhysics player)
    {
        upgrade.Apply(player);
        upgradeManager.OnUpgradeApplied(upgrade);
    }
}
