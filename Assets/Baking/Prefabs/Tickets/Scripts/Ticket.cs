using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour
{
    public int id { get; private set; }
    private float time;
    public Dictionary<int, int> cakesToCounts { get; private set; }

    [SerializeField] Timer timer;

    [SerializeField] TicketImage ticketImage;
    [SerializeField] RawImage[] ticketNumberDigits;
    [SerializeField] RawImage[] timeDigits;

    [SerializeField] RawImage[] cakeImages;
    [SerializeField] RawImage[] cakeDigits;
    [SerializeField] RawImage[] cakeXs;

    public TicketDestroyedEvent ticketDestroyedEvent;

    private void Update()
    {
        setTimeUI(timer.timeLeft);
    }

    public float getTimeLeft()
    {
        return timer.timeLeft;
    }

    public void setTicket(int id, float time, Dictionary<int, int> cakesToCounts)
    {
        this.id = id;
        this.time = time;
        this.cakesToCounts = cakesToCounts;

        timer.timeUpEvent.AddListener(onTimeUp);

        setTicketNumberUI();
        setCakeUI();
    }

    private void setTicketNumberUI()
    {
        int idCopy = id;
        if (idCopy > 999)
        {
            Debug.Log("Ticket Error!");
        } else
        {
            int index = 2;
            while (index >= 0)
            {
                ticketNumberDigits[index].texture = ticketImage.getDigit(idCopy % 10);
                idCopy /= 10;
                index -= 1;
            }
        }
    }

    private void setTimeUI(float timeLeft)
    {
        float timeToDisplay = timeLeft + 1;
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeDigits[3].texture = ticketImage.getDigit(seconds % 10);
        timeDigits[2].texture = ticketImage.getDigit(seconds/10 % 10);
        timeDigits[1].texture = ticketImage.getDigit(minutes % 10);
        timeDigits[0].texture = ticketImage.getDigit(minutes/10 % 10);
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

    private void setCakeUI()
    {
        if (cakesToCounts.Count > 3)
        {
            Debug.Log("Too many cake types!");
        }
        else
        {
            int index = 0;
            foreach (int cake in cakesToCounts.Keys)
            {
                cakeImages[index].texture = ticketImage.getCake(cake);
                cakeDigits[index].texture = ticketImage.getDigit(cakesToCounts[cake]);
                index++;
            }

            while (index < 3)
            {
                cakeImages[index].enabled = false;
                cakeDigits[index].enabled = false;
                cakeXs[index].enabled = false;
                index++;
            }
        }
    }

}
