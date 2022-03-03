using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSubmissionPad : MonoBehaviour
{
    [SerializeField] TicketManager ticketManager;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.GetComponent<Cake>() != null)
        {
            ticketManager.submittedCake = collision.transform.GetComponent<Cake>();
            ticketManager.onOrderReady();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ticketManager.submittedCake = null;
    }
}
