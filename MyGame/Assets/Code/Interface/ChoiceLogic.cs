using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceLogic : MonoBehaviour
{
    private Upgrades[] upgrades;
    [SerializeField] private GameObject[] Card;



   

    void Start()
    {
        upgrades = Resources.LoadAll<Upgrades>("Upgrades");
    }

    public void DisplayRandomUpgradeChoice()
    {
        var allUpgradesExhausting = new List<Upgrades>(upgrades);
        for (int i = 0; i < Card.Length; i++)
        {
            var rnd = Random.Range(0, allUpgradesExhausting.Count);
            
            allUpgradesExhausting.RemoveAt(rnd);
        }
    }
}
