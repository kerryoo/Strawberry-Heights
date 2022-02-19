using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Ticket : MonoBehaviour
{
    private int id;
    public string cakeType;
    public Dictionary<String, int> toppingsToCount = new Dictionary<String, int>();
    private float time;

    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI timeLeftText;
    [SerializeField] TextMeshProUGUI ticketNumberText;
    [SerializeField] TextMeshProUGUI ticketCakeType;
    [SerializeField] TextMeshProUGUI ticketToppingType;
    public TicketDestroyedEvent ticketDestroyedEvent;

    private void Update()
    {
        timeLeftText.SetText(timer.getTimeLeftString());
    }

    public void setTicket(int id, string cakeType, Dictionary<string, int> toppingsToCount, float time)
    {
        this.id = id;
        this.cakeType = cakeType;
        this.toppingsToCount = toppingsToCount;
        this.time = time;

        // set id
        ticketNumberText.SetText("Ticket #" + id);
        // set cakeType text
        //ticketCakeType.SetText(cakeType + " Cake");
        // set topping+ amount text
        string toppingText = "";
        foreach (KeyValuePair<string, int> pair in toppingsToCount)
        {
            toppingText += string.Format("{0} x{1}, ", pair.Key, pair.Value);
        }
        //ticketToppingType.SetText(toppingText);
        Debug.Log("Ticket: " + cakeType + " Cake, " + toppingText);
        // set time
        timer.timeUpEvent.AddListener(onTimeUp);
    }

    public void startTimer()
    {
        timer.setTimer(time);
    }

    private void onTimeUp()
    {
        if (ticketDestroyedEvent != null)
        {
            ticketDestroyedEvent.Invoke(id);
        } else
        {
            Debug.Log("Ticket destroyed event had no action.");
        }
        
        timer.timeUpEvent.RemoveAllListeners();
    }


    
}
