using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeUIManagerEnemy : MonoBehaviour
{

    [SerializeField] private UpgradeUI upgradeUIPrefab;
    [SerializeField] private UpgradeManagerEnemy upgradeManagerEnemy;


    public void ShowUpgrades(List<UpgradeEnemy> upgrades)
    {
        gameObject.SetActive(true);

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        StartCoroutine(AwaitChoice(upgrades));
    }

    IEnumerator AwaitChoice(List<UpgradeEnemy> upgrades)
    {
        int i = 0;
        System.Random rnd = new();
        upgrades = upgrades.OrderBy(x => rnd.Next()).ToList();
        foreach (var upgrade in upgrades)
        {
            i++;
            if (i == 4)
                break;
            var ui = Instantiate(upgradeUIPrefab, transform);
            ui.Setup(upgrade.title, upgrade.icon, upgrade.description, () => OnCLickApply(upgrade));
        }
        yield return new WaitForSecondsRealtime(3f);
        int randomIndex = Random.Range(0, upgrades.Count);
        OnCLickApply(upgrades[randomIndex]);
    }

        public void HideUpgrades()
    {
        gameObject.SetActive(false);
    }

    void OnCLickApply(UpgradeEnemy upgrade)
    {
        upgrade.ApplyEnemy();
        upgradeManagerEnemy.OnUpgradeApplied(upgrade);
    }
}


