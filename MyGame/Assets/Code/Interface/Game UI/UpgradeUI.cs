using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Image icon;

    [SerializeField] private Text description;

    private Action applyAction;
    public void Setup(string title, Sprite artwork, string description, Action onApply)
    {
        this.title.text = title;
        this.icon.sprite = artwork;
        this.description.text = description;   
        this.applyAction = onApply;

    }

    public void Apply()
    {
        applyAction?.Invoke();
    }
}
