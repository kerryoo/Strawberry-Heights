using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketManager : MonoBehaviour
{
    [SerializeField] GameObject ticketGameObject;
    private Dictionary<int, Ticket> idToTicket;
    private int ticketNumber = 0;

    private void Start()
    {
        idToTicket = new Dictionary<int, Ticket>();
    }

    public void createTicket(string cakeType, Dictionary<Topping, int> toppingsToCount, float time)
    {
        GameObject ticketObj = Instantiate(ticketGameObject);

        Ticket ticket = ticketObj.GetComponent<Ticket>();
        ticket.setTicket(ticketNumber, cakeType, toppingsToCount, time);

        idToTicket[ticketNumber] = ticket;

        ticket.ticketDestroyedEvent.AddListener(onTicketDestroyed);
        ticketNumber++;
    }

    private void onTicketDestroyed(int id)
    {
        Ticket destroyedTicket = idToTicket[id];
        destroyedTicket.ticketDestroyedEvent.RemoveAllListeners();
        idToTicket.Remove(id);
        Debug.Log("Ticket " + id + " Timed out!");
    }

    public void dayReset()
    {
          
    }

}
