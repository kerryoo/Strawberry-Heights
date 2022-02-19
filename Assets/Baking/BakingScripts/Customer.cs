using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float rotationSpeed = 200;

    [SerializeField] private Animator customerAnimator;

    private Vector3 targetPosition;
    [SerializeField] float targetPositionTolerance = 1f;

    private bool inPosition = false;
    public bool acting { get; private set; }
    private int ticketID = -1;

    public OrderPlacedEvent orderPlacedEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //makeOrder();
            customerAnimator.SetBool("Win", true);
        }
    }

    public void initializeCustomer(int ticketID, Vector3 registerLocation)
    {
        this.ticketID = ticketID;
        targetPosition = registerLocation;
    }

    private void moveToTargetPos()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        Vector3 nextPosition = new Vector3(0, 0, movementSpeed * Time.deltaTime);
        customerAnimator.SetFloat("MoveSpeed", 1f);

        transform.Translate(nextPosition);
    }

    public void startOrder()
    {
        acting = true;
        StartCoroutine(goToRegisterRoutine());
    }

    IEnumerator goToRegisterRoutine()
    {
        while (!inPosition)
        {
            moveToTargetPos();
            if (Vector3.Distance(targetPosition, transform.position) <= targetPositionTolerance)
            {
                inPosition = true;
            }
            yield return null;
        }
        customerAnimator.SetFloat("MoveSpeed", 0);
        inPosition = false;
        StartCoroutine(placeOrderRoutine());
    }

    IEnumerator placeOrderRoutine()
    {
        customerAnimator.SetBool("Conversation", true);
        yield return new WaitForSeconds(3f);
        if (orderPlacedEvent != null)
        {
            orderPlacedEvent.Invoke(ticketID);
        } else
        {
            Debug.Log("No order event!");
        }
    }
}
