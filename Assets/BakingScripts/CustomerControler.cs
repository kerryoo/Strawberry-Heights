using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerControler : MonoBehaviour
{
    private void Start()
    {
        GetComponent<NavMeshAgent>().destination = GameObject.Find("Submission Pad").transform.position + Vector3.right;
    }
}
