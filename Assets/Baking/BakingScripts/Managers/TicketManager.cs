using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketManager : MonoBehaviour
{
    [SerializeField] GameObject ticketPrefab;
    [SerializeField] GameObject customerPrefab;
    [SerializeField] Vector3 registerLocation;

    private Dictionary<int, Ticket> idToTicket;
    private Dictionary<int, Customer> idToCustomer;
    
    private int ticketNumber = 0;

    private void Start()
    {
        idToTicket = new Dictionary<int, Ticket>();
        idToCustomer = new Dictionary<int, Customer>();
    }

    public void createCustomer()
    {
        ticketNumber++;

        GameObject customerObj = Instantiate(customerPrefab);
        Customer customer = customerObj.GetComponent<Customer>();
        idToCustomer[ticketNumber] = customer;
        customer.initializeCustomer(ticketNumber, registerLocation);
        customer.orderPlacedEvent.AddListener(onOrderPlaced);

        customer.startOrder();
    }

    private void writeTicket(int id, Ticket ticket)
    {
        Topping strawberry = new Topping(ToppingType.Strawberry);
        Dictionary<Topping, int> justOneStrawberry = new Dictionary<Topping, int>();
        justOneStrawberry[strawberry] = 1;

        ticket.setTicket(id, CakeType.Lemon, justOneStrawberry, BalanceSheet.timePerTicket);
        ticket.ticketDestroyedEvent.AddListener(onTicketDestroyed);
    }

    private void onTicketDestroyed(int id)
    {
        Ticket destroyedTicket = idToTicket[id];
        destroyedTicket.ticketDestroyedEvent.RemoveAllListeners();
        idToTicket.Remove(id);
        Debug.Log("Ticket " + id + " Timed out!");
    }

    private void createTicket(int id)
    {
        GameObject ticketObj = Instantiate(ticketPrefab);

        Ticket ticket = ticketObj.GetComponent<Ticket>();
        writeTicket(id, ticket);
        idToTicket[id] = ticket;

        ticket.startTimer();
    }

    private void onOrderPlaced(int id)
    {
        Customer orderingCustomer = idToCustomer[id];
        orderingCustomer.orderPlacedEvent.RemoveAllListeners();
        createTicket(id);
        //Start waiting

    }

    public void dayReset()
    {
          
    }

}
