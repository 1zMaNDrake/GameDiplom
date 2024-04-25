using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    public string title;
    public Sprite icon;
    public string description;

    public abstract void Apply(PlayerPhysics player);
}
