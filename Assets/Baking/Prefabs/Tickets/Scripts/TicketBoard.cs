using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class TicketBoard : MonoBehaviour
{
    [SerializeField] PlacePoint[] ticketPlacePoints;

    public void addTicket(Ticket ticket)
    {
        int i = 0;

        while (i < ticketPlacePoints.Length && ticketPlacePoints[i].placedObject != null)
        {
            i++;
        }

        if (i == ticketPlacePoints.Length)
        {
            Debug.Log("Ticket queue full!");
        } else
        {
            ticketPlacePoints[i].Place(ticket.GetComponent<Grabbable>());
        }
    }

    //[SerializeField] Transform[] connectPositions;
    //[SerializeField] GameObject[] connectPlaceholders;

    //private int lowestDistanceIndex = 0;
    //private Ticket lowestDistanceTicket;
    //private void OnTriggerStay(Collider other)
    //{
    //    Ticket ticket = other.GetComponent<Ticket>();
    //    if (ticket != null)
    //    {
    //        float lowestDistance = 1000f;

    //        for (int i = 0; i < connectPositions.Length; i++)
    //        {
    //            float currDistance = Vector3.Distance(connectPositions[i].position, ticket.transform.position);
    //            if (currDistance < lowestDistance)
    //            {
    //                lowestDistance = currDistance;
    //                lowestDistanceIndex = i;
    //                lowestDistanceTicket = ticket;
    //            }
    //        }

    //        for (int i = 0; i < connectPositions.Length; i++)
    //        {
    //            if (i == lowestDistanceIndex)
    //            {
    //                connectPlaceholders[lowestDistanceIndex].SetActive(true);
    //            } else
    //            {
    //                connectPlaceholders[i].SetActive(false);
    //            }
    //        }


    //    }
    //    else
    //    {
    //        foreach (GameObject connectPlaceholder in connectPlaceholders)
    //        {
    //            connectPlaceholder.SetActive(false);
    //        }
    //        lowestDistanceTicket = null;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    connectPlaceholders[lowestDistanceIndex].SetActive(false);
    //    lowestDistanceTicket = null;
    //}

    //public void onTicketRelease(Ticket releasedTicket)
    //{
    //    if (releasedTicket == lowestDistanceTicket)
    //    {
    //        releasedTicket.GetComponent<Rigidbody>().isKinematic = true;
    //        releasedTicket.transform.SetPositionAndRotation(connectPositions[lowestDistanceIndex].position, Quaternion.identity);
    //    }
    //}
}
