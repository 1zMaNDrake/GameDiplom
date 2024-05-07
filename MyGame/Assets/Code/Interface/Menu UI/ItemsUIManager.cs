using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsUIManager : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text description;
    [SerializeField] private ItemsUI UIPrefab;
    [SerializeField] private AlmanacManager almanacManager;

    private void OnDisable()
    {
        title.text = "";
        description.text = "";
    }
    public void ShowItems(List<Enemy> enemies)
    {
        RemoveExistingUIComponents();

        foreach (var enemy in enemies)
        {
            var ui = Instantiate(UIPrefab, transform);
            ui.Setup(enemy.title, enemy.icon, () => OnCLickApply(enemy.title, enemy.description));
        }
    }
    public void ShowEnemies(List<Enemy> enemies)
    {
        RemoveExistingUIComponents();

        foreach (var enemy in enemies)
        {
            var ui = Instantiate(UIPrefab, transform);
            ui.Setup(enemy.title, enemy.icon, () => OnCLickApply(enemy.title, enemy.description));
        }
    }

    void OnCLickApply(string title, string description)
    {
        this.title.text = title;
        this.description.text = description;
    }

    public void RemoveExistingUIComponents()
    {
        gameObject.SetActive(true);

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
