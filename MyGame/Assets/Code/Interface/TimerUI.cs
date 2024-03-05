using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    private int sec = 0;
    private int min = 0;
    public bool isTimerRunning;
    private TMP_Text _TimerText;
    [SerializeField] private int delta = 0;

    private void Start()
    {
        _TimerText = GameObject.Find("TimerText").GetComponent<TMP_Text>();
        StartCoroutine(ITimer());
    }

    IEnumerator ITimer()
    {
        while(true)
        {
            if(sec ==59)
            {
                min++;
                sec = -1;
            }
            sec += delta;
            _TimerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
