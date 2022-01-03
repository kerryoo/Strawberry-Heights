using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerControler : MonoBehaviour
{
    private BakeryManager bm;
    private NavMeshAgent agent;
    private bool state = true;

    private void Start()
    {
        GameObject bakeryManager = GameObject.Find("Bakery Manager");
        bm = bakeryManager.GetComponent<BakeryManager>();

        agent = GetComponent<NavMeshAgent>();
        agent.destination = bm.backOfLine();
    }

    private void Update()
    {
        if (agent.remainingDistance == 0 && state)
        {
            state = false;
            Debug.Log("hi");
            bm.AddToBack(gameObject.transform.position);
            
        }
    }
}
