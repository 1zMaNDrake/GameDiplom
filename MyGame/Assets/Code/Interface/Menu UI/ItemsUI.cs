using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsUI : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Image icon;
    [SerializeField] private Text description;

    private Action applyAction;

    public void Setup(string title, Sprite artwork, Action onApply)
    {
        this.title.text = title;
        this.icon.sprite = artwork;
        this.applyAction = onApply;
    }

    public void Click()
    {
        applyAction?.Invoke();
    }
}
