using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketSubmissionPad : MonoBehaviour
{
    [SerializeField] TicketManager ticketManager;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.GetComponent<Ticket>() != null)
        {
            ticketManager.submittedTicket = collision.transform.GetComponent<Ticket>();
            ticketManager.onOrderReady();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ticketManager.submittedTicket = null;
    }
}
