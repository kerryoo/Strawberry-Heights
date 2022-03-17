using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSubmissionPad : MonoBehaviour
{
    [SerializeField] BakeryManager bakeryManager;
    private void OnCollisionEnter(Collision collision)
    {
        Box collidedBox = collision.transform.GetComponent<Box>();
        if (collidedBox != null && collidedBox.gradeable() && !collidedBox.submitted)
        {
            collidedBox.submitted = true;
            bakeryManager.gradeCake(collidedBox.connectedDesserts,
                collidedBox.attachedTicket.cakesToCounts,
                collidedBox.attachedTicket.getTimeLeft(),
                collidedBox.attachedTicket.id);
        }
    }

}
