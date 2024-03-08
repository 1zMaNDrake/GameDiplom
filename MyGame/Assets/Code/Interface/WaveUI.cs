using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveUI : MonoBehaviour
{
    [SerializeField] private WaveData _waveData;
    private TMP_Text _waveText;

    private void Start()
    {
        _waveText = GameObject.Find("WaveProgress").GetComponent<TMP_Text>();
       
    }

    private void Update()
    {
        _waveText.text = "Wave: " + (_waveData.nextWave + 1).ToString();  
    }
}
