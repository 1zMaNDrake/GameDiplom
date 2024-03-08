using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class Upgrades : ScriptableObject
{
	public new string name;
	public string description;
	public Sprite artwork;
	public GameObject updatePrefab;
	public float rechargeBullet;
}
