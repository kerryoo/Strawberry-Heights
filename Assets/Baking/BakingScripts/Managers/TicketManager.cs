using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TicketManager : MonoBehaviour
{
    [SerializeField] GameObject ticketPrefab;
    [SerializeField] GameObject customerPrefab;
    [SerializeField] Vector3 registerLocation;
    [SerializeField] BakeryManager bakeryManager;

    private Dictionary<int, Ticket> idToTicket;
    private Dictionary<int, Customer> idToCustomer;
    int day;

    private List<string> possibleCakeTypes;
    private List<string> possibleToppingTypes;

    private int ticketNumber = 0;

    private void Start()
    {
        idToTicket = new Dictionary<int, Ticket>();
        idToCustomer = new Dictionary<int, Customer>();
    }

    public void newDay(int day)
    {
        this.day = day; // change the day/difficulty here for now (default is 1, max: 6)
        PossibleType possibleType = new PossibleType();
        possibleCakeTypes = possibleType.getPossibleCakeTypes(this.day);
        possibleToppingTypes = possibleType.getPossibleToppingTypes(this.day);
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
        //Choose 1 random cakeType
        System.Random rnd = new System.Random();
        string cakeType = possibleCakeTypes[rnd.Next(possibleCakeTypes.Count)];

        //Choose random topping and amont and add to Dictionary
        Dictionary<string, int> toppings = new Dictionary<string, int>();
        foreach (string topping in possibleToppingTypes)
        {
            int toppingAmount = rnd.Next(((day+1)/2)*2+1);
            if (toppingAmount > 0)
            {
                toppings.Add(topping, toppingAmount);
            }

        }

        ticket.setTicket(id, cakeType, toppings, BalanceSheet.timePerTicket);
        ticket.ticketDestroyedEvent.AddListener(onTicketDestroyed);
    }

    private void onTicketDestroyed(int id)
    {
        Ticket destroyedTicket = idToTicket[id];
        destroyedTicket.ticketDestroyedEvent.RemoveAllListeners();
        idToTicket.Remove(id);
        //Debug.Log("Ticket " + id + " Timed out!");
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
