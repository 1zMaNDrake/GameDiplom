using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AlmanacManager : MonoBehaviour
{
    [SerializeField] private ItemsUIManager uiManager;

    public Enemy[] enemies;
    public Enemy[] upgrades;

    private List<Enemy> knowedItems;
    private List<Enemy> knowedEnemies;

    private void Awake()
    {
        knowedEnemies = enemies.ToList();
        knowedItems = upgrades.ToList();
    }

    public void ShowItems()
    {
        if (knowedItems.Count > 0)
        {
            uiManager.ShowItems(knowedItems);
        }
    }

    public void ShowEnemies()
    {
        if (knowedItems.Count > 0)
        {
            uiManager.ShowEnemies(knowedEnemies);
        }
    }

}
