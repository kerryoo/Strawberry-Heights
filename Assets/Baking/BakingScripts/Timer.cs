using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft { get; private set; }
    public TimeUpEvent timeUpEvent;

    public void setTimer(float time)
    {
        timeLeft = time;
        StartCoroutine(TimerRoutine());
        //Debug.Log("Timer started");
    }

    public string getTimeLeftString()
    {
        float timeToDisplay = timeLeft + 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator TimerRoutine()
    {
        while (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }
        timeLeft -= Time.deltaTime;

        if (timeUpEvent != null)
        {
            timeUpEvent.Invoke();
        } else
        {
            Debug.Log("Buzz Buzz");
        }
        
    }

}
