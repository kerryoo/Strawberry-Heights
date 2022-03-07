using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatedCustomer : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Sitting", true);
 
        transform.localPosition = new Vector3(0, 0.3f, 0.3f);
        transform.localRotation = Quaternion.identity;
        transform.localScale = new Vector3(1.33f, 1.33f, 1.33f);


        //This method will make the customer start talking
        //animator.SetBool("Talking", true);
    }

}
