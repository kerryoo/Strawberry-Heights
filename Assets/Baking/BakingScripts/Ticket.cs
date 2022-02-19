using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    private int id;
    public string cakeType;
    public Dictionary<Topping, int> toppingsToCount = new Dictionary<Topping, int>();
    private float time;

    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI timeLeftText;
    [SerializeField] TextMeshProUGUI ticketNumberText;
    public TicketDestroyedEvent ticketDestroyedEvent;

    private void Update()
    {
        timeLeftText.SetText(timer.getTimeLeftString());
    }

    public void setTicket(int id, string cakeType, Dictionary<Topping, int> toppingsToCount, float time)
    {
        this.id = id;
        this.cakeType = cakeType;
        this.toppingsToCount = toppingsToCount;
        this.time = time;

        ticketNumberText.SetText("Ticket #" + id);
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
