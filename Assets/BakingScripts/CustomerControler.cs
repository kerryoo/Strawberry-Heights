using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerControler : MonoBehaviour
{
    private BakeryManager bm;
    private NavMeshAgent agent;
    private List<string> pastry = new List<string>();

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GameObject.Find("Submission Pad").transform.position + Vector3.right;
        bm = GameObject.Find("Bakery Manager").GetComponent<BakeryManager>();

        //(TODO) Generate random pastry
        pastry.Add("cube");

        bm.setTargetCake(pastry);
    }

    public void leaveStore()
    {
        agent.destination = new Vector3(0, 0, 0);
    }

}
