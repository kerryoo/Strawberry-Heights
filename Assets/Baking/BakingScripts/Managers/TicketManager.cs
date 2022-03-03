using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketManager : MonoBehaviour
{
    [SerializeField] GameObject ticketPrefab;
    [SerializeField] GameObject customerPrefab;
    [SerializeField] Transform registerLocation;
    [SerializeField] Transform registerLookLocation;

    [SerializeField] Transform customerSpawnLocation;
    [SerializeField] Transform waitLocation;

    [SerializeField] Transform pickUpLocation;

    [SerializeField] Transform ticketSpawnLocation;

    [SerializeField] BakeryManager bakeryManager;

    [SerializeField] Transform[] lineWaitLocations;
    [SerializeField] Transform[] lineLookLocations;

    [SerializeField] TutorialTeo tutorialTeo;
    [SerializeField] TicketBoard ticketBoard;

    private Dictionary<int, Ticket> idToTicket;
    private Dictionary<int, Customer> idToCustomer;
    private List<Customer> customerLine;

    private int ticketNumber = 0;

    public Ticket submittedTicket;
    public Cake submittedCake;

    private void Start()
    {
        idToTicket = new Dictionary<int, Ticket>();
        idToCustomer = new Dictionary<int, Customer>();
        customerLine = new List<Customer>();
    }

    public void createCustomer()
    {
        ticketNumber++;

        GameObject customerObj = Instantiate(customerPrefab, customerSpawnLocation.position, Quaternion.identity);
        Customer customer = customerObj.GetComponent<Customer>();
        idToCustomer[ticketNumber] = customer;
        customer.initializeCustomer(ticketNumber);
        customer.customerOrderingEvent.AddListener(onCustomerOrdering);
        customer.orderPlacedEvent.AddListener(onOrderPlaced);

        customerLine.Add(customer);

        if (customerLine.Count == 1)
        {
            moveLine();
        } else
        {
            int customerIndex = customerLine.Count - 1;
            customer.moveInLine(lineWaitLocations[customerIndex].position,
                lineLookLocations[getLookLocationIndex(customerIndex)].position);
        }
    }

    private void writeTicket(int id, Ticket ticket)
    {
        Dictionary<int, int> justOneStrawberry = new Dictionary<int, int>();
        justOneStrawberry[(int)ID.ToppingID.Strawberry] = 1;

        ticket.setTicket(id, (int)ID.CakeID.Lemon, justOneStrawberry, BalanceSheet.timePerTicket, this);
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
        ticketBoard.addTicket(ticket);

        writeTicket(id, ticket);
        idToTicket[id] = ticket;

        ticket.startTimer();
    }

    private void onOrderPlaced(int id)
    {
        Customer orderingCustomer = idToCustomer[id];
        orderingCustomer.orderPlacedEvent.RemoveAllListeners();
        createTicket(id);
        customerLine.RemoveAt(0);

        orderingCustomer.goWait(waitLocation.position);
        moveLine();
    }

    private void onCustomerOrdering(int id)
    {
        Customer orderingCustomer = idToCustomer[id];
        orderingCustomer.customerOrderingEvent.RemoveAllListeners();
        tutorialTeo.startTalking(orderingCustomer.transform.position);

    }

    public void onOrderReady()
    {
        if (submittedCake != null && submittedTicket != null)
        {
            Debug.Log("Ticket ready");
            Customer customerToPickUp = idToCustomer[submittedTicket.id];
            customerToPickUp.pickUpOrder(pickUpLocation.position);
        }
    }

    private void moveLine()
    {
        for (int i = 1; i < customerLine.Count; i++)
        {
            customerLine[i].moveInLine(lineWaitLocations[i].position, lineLookLocations[getLookLocationIndex(i)].position);
        }

        customerLine[0].startOrder(registerLocation.position, registerLookLocation.position);
        

    }

    private int getLookLocationIndex(int positionIndex)
    {
        if (positionIndex < 1)
        {
            return 0;
        } else if (positionIndex < 4)
        {
            return 1;
        } else if (positionIndex < 10)
        {
            return 2;
        } else if (positionIndex < 11)
        {
            return 3;
        } else if (positionIndex < 14)
        {
            return 4;
        } else if (positionIndex < 15)
        {
            return 5;
        }
        return -1;
    }

    public void dayReset()
    {
          
    }

}
