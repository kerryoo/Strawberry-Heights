using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSubmissionPad : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Box collidedBox = collision.transform.GetComponent<Box>();
        if (collidedBox != null && collidedBox.gradeable())
        {

        }
    }

}
