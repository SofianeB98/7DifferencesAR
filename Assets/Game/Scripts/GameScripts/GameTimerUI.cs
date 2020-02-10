using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro timerText;

    public void SetTimerText(float time)
    {
        int second = (int)(time % 60 >= 60 ? 0 : time%60);
        int minute = (int)(time / 60 >= 60 ? 0 : time/60);

        this.timerText.text = "Temps - " + minute.ToString("00") + ":" + second.ToString("00");
    }
}
