using System.Collections;
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

  
        foreach (var upgrade in upgrades)
        {

            var ui = Instantiate(upgradeUIPrefab, transform);
            ui.Setup(upgrade.title, upgrade.icon, upgrade.description, () => onCLickApply(upgrade, player));
        }
    }

    public void HideUpgrades()
    {
        gameObject.SetActive(false);
    }

    void onCLickApply(Upgrade upgrade, PlayerPhysics player)
    {
        upgrade.Apply(player);
        upgradeManager.onUpgradeApplied(upgrade);
    }
}
