using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveData : MonoBehaviour
{
    public Wave[] waves;
}

[System.Serializable]

public class Wave
{
    [Range(0, 100)]
    [field: SerializeField]
    public int CountOfEnemyInWave;
    [Range(0, 360)]
    [field: SerializeField]
    public float WaitAfterWave;
}
