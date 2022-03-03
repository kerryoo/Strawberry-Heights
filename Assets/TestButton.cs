using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] TicketManager ticketManager;
    private void OnCollisionEnter(Collision collision)
    {
        ticketManager.createCustomer();
    }
}
