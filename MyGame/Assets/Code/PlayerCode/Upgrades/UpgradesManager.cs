using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private UpgradesUIManager uiManager;
    [SerializeField] private Upgrade[] upgrades;
    [SerializeField] private PlayerPhysics player;

    private List<Upgrade> availableUpdrades;

    private void Awake()
    {
        availableUpdrades = upgrades.ToList();
    }
    public void SuggestUpgrade()
    {
       if (availableUpdrades.Count > 0)
        {
            Time.timeScale = 0;
            uiManager.ShowUpgrades(availableUpdrades, player);
        }
    }

    public void OnUpgradeApplied(Upgrade appliedUpdate)
    {
        uiManager.HideUpgrades();
        availableUpdrades.Remove(appliedUpdate);
    }
}
