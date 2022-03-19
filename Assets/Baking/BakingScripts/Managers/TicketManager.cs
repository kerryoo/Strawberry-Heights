using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class TicketManager : MonoBehaviour
{
    [SerializeField] GameObject ticketPrefab;
    [SerializeField] GameObject[] customerPrefabs;
    [SerializeField] Transform[] seats;

    private List<GameObject> customerList;
    private int customerPrefabsIndex;

    [SerializeField] Transform registerLocation;
    [SerializeField] Transform registerLookLocation;

    [SerializeField] Transform customerSpawnLocation;

    [SerializeField] Transform pickUpLocation;

    [SerializeField] Transform[] lineWaitLocations;
    [SerializeField] Transform[] orderWaitLocations;
    private int waitIndex = 0;

    [SerializeField] TutorialTeo tutorialTeo;
    [SerializeField] TicketBoard ticketBoard;

    private Dictionary<int, Ticket> idToTicket;
    private Dictionary<int, Customer> idToCustomer;
    private List<Customer> customerLine;

    private int[] possibleCakes;

    private int ticketNumber = 0;

    public Ticket submittedTicket;
    public Dessert submittedCake;

    private void Start()
    {
        idToTicket = new Dictionary<int, Ticket>();
        idToCustomer = new Dictionary<int, Customer>();
        customerLine = new List<Customer>();
        customerList = customerPrefabs.ToList();
        shuffleCustomerList();
        shuffleSeatArray();
        setSeatedCustomers();
    }

    public void createCustomer()
    {
        ticketNumber++;

        GameObject customerObj = Instantiate(chooseCustomerObj(), customerSpawnLocation.position, Quaternion.identity);
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
            customer.moveInLine(lineWaitLocations[customerIndex].position);
        }
    }

    private void writeTicket(int id, Ticket ticket)
    {
        int index = Random.Range(0, possibleCakes.Length);
        Dictionary<int, int> cakeToCount = new Dictionary<int, int>();

        cakeToCount[possibleCakes[index]] = 1;

        ticket.setTicket(id, BalanceSheet.timePerTicket, cakeToCount);
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

        orderingCustomer.goWait(getWaitLocation().position);
        if (customerLine.Count > 0)
        {
            moveLine();
        }
    }

    private Transform getWaitLocation()
    {
        if (waitIndex > orderWaitLocations.Length)
        {
            waitIndex = 1;
        } else
        {
            waitIndex++;
        }
        return orderWaitLocations[waitIndex - 1];
    }

    private void onCustomerOrdering(int id)
    {
        Customer orderingCustomer = idToCustomer[id];
        orderingCustomer.customerOrderingEvent.RemoveAllListeners();
        tutorialTeo.startTalking(orderingCustomer.transform.position);

    }


    private void moveLine()
    {
        for (int i = 1; i < customerLine.Count; i++)
        {
            customerLine[i].moveInLine(lineWaitLocations[i].position);
        }

        customerLine[0].startOrder(registerLocation.position, registerLookLocation.position);
    }

    private GameObject chooseCustomerObj()
    {
        if (customerPrefabsIndex > customerList.Count)
        {
            customerPrefabsIndex = 1;
            shuffleCustomerList();

        } else
        {
            customerPrefabsIndex++;
        }

        return customerList[customerPrefabsIndex - 1];
    }

    private void shuffleCustomerList()
    {
        int n = customerList.Count;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            GameObject temp = customerList[n];
            customerList[n] = customerList[k];
            customerList[k] = temp;
        }
    }

    private void shuffleSeatArray()
    {
        int n = seats.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            Transform temp = seats[n];
            seats[n] = seats[k];
            seats[k] = temp;
        }
    }

    private void setSeatedCustomers()
    {
        int numberOfCustomersToSeat= Random.Range(2, 8);
        List<string> tableNames = new List<string>();
        List<SeatedCustomer> seatedCustomers = new List<SeatedCustomer>();

        for (int i = 0; i < numberOfCustomersToSeat; i++)
        {
            string currTableName = seats[i].name.Remove(seats[i].name.Length-1, 1);
            tableNames.Add(currTableName);

            GameObject customerToSeat = Instantiate(customerList[i], seats[i]);
            Destroy(customerToSeat.GetComponent<NavMeshAgent>());
            Destroy(customerToSeat.GetComponent<Customer>());
            SeatedCustomer seatedCustomer = customerToSeat.AddComponent<SeatedCustomer>();

            seatedCustomers.Add(seatedCustomer);
        }


        for (int i = 0; i < tableNames.Count - 1; i++)
        {
            for (int j = i + 1; j < tableNames.Count; j++)
            {
                if (tableNames[i] == tableNames[j])
                {
                    seatedCustomers[i].hasTablePartner = true;
                    seatedCustomers[j].hasTablePartner = true;
                }
            }
        }

        
        customerList.RemoveRange(0, numberOfCustomersToSeat);

    }

    public void onTicketComplete(int ticketId, int reactionId)
    {
        idToCustomer[ticketId].onOrderCompleted(reactionId, pickUpLocation.position);

        idToCustomer.Remove(ticketId);
        idToTicket.Remove(ticketId);
    }

    public void onNewDay(int day, int level)
    {
        possibleCakes = BalanceSheet.levelToPossibleCakes[level];
    }

    public void dayReset()
    {
          
    }

}
