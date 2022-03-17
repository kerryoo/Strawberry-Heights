using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;
using System;

public class Box : MonoBehaviour
{
    [SerializeField] PlacePoint ticketPlacePoint;
    [SerializeField] SphereCollider placePointCollider;

    public List<Dessert> connectedDesserts { get; private set; }

    public bool submitted = false;

    [SerializeField] Transform cakePlacePosition;
    [SerializeField] Transform[] slicePlacePositions;
    private int sliceIndex = 0;
    public Ticket attachedTicket { get; private set; }

    private void Start()
    {
        connectedDesserts = new List<Dessert>();
        disablePlaceholder();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Dessert dessert = collision.transform.GetComponent<Dessert>();

        if (dessert != null && collision.relativeVelocity.magnitude > BalanceSheet.minCollisionMag)
        {
            int cakeShape = dessert.getCakeShape();

            if (cakeShape == (int)ID.CakeShapeID.Cake && connectedDesserts.Count == 0)
            {
                placeDessertInBox(dessert, cakePlacePosition);
                connectedDesserts.Add(dessert);
                enablePlaceholder();

            }
            else if (cakeShape == (int)ID.CakeShapeID.Slice && connectedDesserts.Count < 8
                && (connectedDesserts.Count == 0 || connectedDesserts[0].getCakeShape() == (int)ID.CakeShapeID.Slice))
            {
                placeDessertInBox(dessert, slicePlacePositions[sliceIndex]);
                sliceIndex++;
                connectedDesserts.Add(dessert);
                enablePlaceholder();
            }
        }
    }

    private void placeDessertInBox(Dessert dessert, Transform location)
    {
        dessert.transform.GetComponent<Grabbable>().ForceHandsRelease();
        Destroy(dessert.GetComponent<Rigidbody>());
        dessert.GetComponent<Collider>().enabled = false;
        dessert.GetComponent<Grabbable>().enabled = false;

        dessert.transform.parent = transform;
        dessert.transform.localPosition = location.localPosition;
        dessert.transform.localRotation = location.localRotation;
    }

    public void onPullApart()
    {
        if (connectedDesserts.Count == 0)
        {
            //TODO play bad sound;
        } else
        {
            GetComponent<Grabbable>().ForceHandsRelease();
            foreach (Dessert connectedDessert in connectedDesserts)
            {
                Rigidbody dessertBody = connectedDessert.gameObject.AddComponent<Rigidbody>();
                dessertBody.mass = BalanceSheet.typeToWeight[connectedDessert.getCakeShape()];
                connectedDessert.GetComponent<Collider>().enabled = true;

                Grabbable grab = connectedDessert.GetComponent<Grabbable>();
                grab.enabled = true;
                grab.body = dessertBody;


                connectedDessert.transform.localPosition = new Vector3(0.5f, 0, 0);
                connectedDessert.transform.parent = null;
            }

            connectedDesserts.Clear();
            sliceIndex = 0;
            disablePlaceholder();
        }
    }

    public void onTicketPlace()
    {
        attachedTicket = ticketPlacePoint.placedObject.GetComponent<Ticket>();
        Debug.Log(attachedTicket);
    }

    public void onTicketRemove()
    {
        attachedTicket = null;
    }

    private void disablePlaceholder()
    {
        ticketPlacePoint.enabled = false;
        placePointCollider.enabled = false;
    }

    private void enablePlaceholder()
    {
        placePointCollider.enabled = true;
        ticketPlacePoint.enabled = true;
    }

    public bool gradeable()
    {
        return attachedTicket != null && connectedDesserts.Count != 0;
    }
}
