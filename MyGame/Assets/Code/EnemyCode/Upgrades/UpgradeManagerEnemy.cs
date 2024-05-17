using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManagerEnemy : MonoBehaviour
{
    [SerializeField] private UpgradeUIManagerEnemy uiManager;
    [SerializeField] private UpgradeEnemy[] upgrades;

    private List<UpgradeEnemy> availableUpdrades;

    private void Awake()
    {
        availableUpdrades = upgrades.ToList();
    }
    public void SuggestUpgradeEnemy()
    {
        if (availableUpdrades.Count > 0)
        {
            uiManager.ShowUpgrades(availableUpdrades);
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void OnUpgradeApplied(UpgradeEnemy appliedUpdateEnemy)
    {
        uiManager.HideUpgrades();
        availableUpdrades.Remove(appliedUpdateEnemy);
        Time.timeScale = 1f;
    }
}