using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeEnemy : MonoBehaviour
{
    public string title;
    public Sprite icon;
    public string description;

    public abstract void ApplyEnemy();
}
