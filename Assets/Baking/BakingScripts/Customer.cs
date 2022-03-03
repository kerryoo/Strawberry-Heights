using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    [SerializeField] private Animator customerAnimator;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] float targetPositionTolerance = 1f;
    [SerializeField] float targetRotationTolerance = 0.1f;


    public bool acting { get; private set; }
    private int ticketID = -1;

    public OrderPlacedEvent orderPlacedEvent;
    public CustomerOrderingEvent customerOrderingEvent;

    private void Update()
    {
    }

    public void initializeCustomer(int ticketID)
    {
        this.ticketID = ticketID;
    }

    public void moveInLine(Vector3 lineLocation, Vector3 lineLookLocation)
    {
        StartCoroutine(goToLinePositionRoutine(lineLocation, lineLookLocation));
    }

    public void startOrder(Vector3 registerLocation, Vector3 registerLookLocation)
    {
        acting = true;
        StartCoroutine(goToRegisterRoutine(registerLocation, registerLookLocation));
    }

    public void goWait(Vector3 waitingLocation)
    {
        StartCoroutine(goToWaitingRoutine(waitingLocation));
    }

    public void pickUpOrder(Vector3 pickUpLocation)
    {
        StartCoroutine(pickUpRoutine(pickUpLocation));
    }

    IEnumerator goToLinePositionRoutine(Vector3 lineLocation, Vector3 lookLocation)
    {
        yield return StartCoroutine(goToLocation(lineLocation));
        yield return StartCoroutine(goToRotation(lookLocation));
    }

    IEnumerator goToRegisterRoutine(Vector3 registerLocation, Vector3 registerLookLocation)
    {
        yield return StartCoroutine(goToLocation(registerLocation));
        yield return StartCoroutine(goToRotation(registerLookLocation));

        StartCoroutine(placeOrderRoutine());
    }

    IEnumerator placeOrderRoutine()
    {
        customerOrderingEvent.Invoke(ticketID);
        customerAnimator.SetBool("Conversation", true);
        yield return new WaitForSeconds(10f);
        if (orderPlacedEvent != null)
        {
            orderPlacedEvent.Invoke(ticketID);
        } else
        {
            Debug.Log("No order event!");
        }
    }

    IEnumerator goToWaitingRoutine(Vector3 waitingLocation)
    {
        yield return StartCoroutine(goToLocation(waitingLocation));
    }

    IEnumerator pickUpRoutine(Vector3 pickUpLocation)
    {
        yield return StartCoroutine(goToLocation(pickUpLocation));
        customerAnimator.SetBool("Dance", true);
    }

    IEnumerator goToLocation(Vector3 targetPos)
    {
        bool inPosition = false;

        while (!inPosition)
        {
            navMeshAgent.destination = targetPos;
            customerAnimator.SetFloat("MoveSpeed", 1f);

            if (Vector3.Distance(targetPos, transform.position) <= targetPositionTolerance)
            {
                inPosition = true;
            }
            yield return null;
        }
        customerAnimator.SetFloat("MoveSpeed", 0);
    }

    IEnumerator goToRotation(Vector3 lookLocation)
    {
        bool inRotation = false;
        Vector3 relativePos = lookLocation - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(relativePos);
        float timeCount = 0;

        while (!inRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, timeCount);
            timeCount = timeCount + Time.deltaTime;
            if (Quaternion.Angle(transform.rotation, targetRot) <= targetRotationTolerance)
            {
                inRotation = true;
            }
            yield return null;
        }
    }



    public void onOrderCompleted()
    {

    }

    public void onTicketTimeOut()
    {

    }
}
