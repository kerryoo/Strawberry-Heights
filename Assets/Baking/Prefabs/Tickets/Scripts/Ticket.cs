using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour
{
    public int id { get; private set; }
    public int cakeType;
    public Dictionary<int, int> toppingsToCount;

    private float time;
    private bool beingHeld = false;
    private bool nearTicketBoard = false;
    private TicketManager ticketManager;

    private FixedJoint stickiness;

    [SerializeField] Timer timer;

    [SerializeField] TicketImage ticketImage;
    [SerializeField] RawImage[] ticketNumberDigits;
    [SerializeField] RawImage[] timeDigits;
    [SerializeField] RawImage cakeImage;
    [SerializeField] RawImage[] toppingImages;
    [SerializeField] RawImage[] toppingDigits;
    [SerializeField] RawImage[] toppingXs;

    public TicketDestroyedEvent ticketDestroyedEvent;

    private void Update()
    {
        setTimeUI(timer.timeLeft);
    }

    public void setTicket(int id, int cakeType, Dictionary<int, int> toppingsToCount, float time, TicketManager ticketManager)
    {
        this.id = id;
        this.cakeType = cakeType;
        this.toppingsToCount = toppingsToCount;
        this.time = time;
        this.ticketManager = ticketManager;

        timer.timeUpEvent.AddListener(onTimeUp);

        setTicketNumberUI();
        setCakeUI();
        setToppingsUI();
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

    private void setCakeUI()
    {
        cakeImage.texture = ticketImage.getCake(cakeType);
    }

    private void setToppingsUI()
    {
        if (toppingsToCount.Count > 3)
        {
            Debug.Log("Too many topping types!");
        } else
        {
            int index = 2;
            while (index > toppingsToCount.Count - 1)
            {
                toppingImages[index].enabled = false;
                toppingDigits[index].enabled = false;
                toppingXs[index].enabled = false;
                index--;
            }

            index = 0;
            foreach (int topping in toppingsToCount.Keys)
            {
                toppingImages[index].texture = ticketImage.getTopping(topping);
                toppingDigits[index].texture = ticketImage.getDigit(toppingsToCount[topping]);
                index++;
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

    private void setNearTicketBoard(bool nearTicketBoard)
    {
        this.nearTicketBoard = nearTicketBoard;
    }

    // //Stickiness
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (!beingHeld && collision.transform.GetComponent<TicketBoard>() != null)
    //     {
    //         stickiness = gameObject.AddComponent<FixedJoint>();
    //         stickiness.connectedBody = collision.rigidbody;
    //     }
    // }

    //public void OnGrab()
    //{
    //     Destroy(stickiness);
    //     beingHeld = true;
    //}



}
