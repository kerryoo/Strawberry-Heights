using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Infoboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI dayNumberText;
    [SerializeField] Timer DayTimer;

    public void updateDayTimerUI()
    {
        timerText.SetText(DayTimer.getTimeLeftString());
    }

    public void onNewDay(int day, int level)
    {
        dayNumberText.SetText(day.ToString());
    }


}
