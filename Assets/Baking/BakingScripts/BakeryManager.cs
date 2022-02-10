using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BakeryManager : GameManager
{
    // Game management
    private List<string> targetCake = new List<string>();

    // Player
    [SerializeField] BakeryPlayer bp;

    // Scoring
    private int score = 0;
    [SerializeField] int points;

    // Customer
    [SerializeField] GameObject customerPreFab;
    [SerializeField] Vector3 customerSpawnPoint;
    private CustomerControler customer;

    private void Start()
    {
        spawnCustomer();
    }

    public void setTargetCake(List<string> target)
    {
        targetCake = target;
    }

    /*
     * Check if the targetCake is the same as the textures. If it is, call
     * onCakeSuccess. If not, call onCakeFailure.
     */
    public void onCakeSubmit(List<string> toppings)
    {
        if (targetCake.Count != toppings.Count)
        {
            onCakeFailure();
            return;
        }

        for (int i = 0; i < toppings.Count; ++i) 
        {
            if (targetCake[i] != toppings[i])
            {
                onCakeFailure();
                return;
            }
        }

        onCakeSuccess();
    }

    /*
     * Do something when the player loses.
     */
    private void onCakeFailure()
    {
        bp.setText("That is not what I wanted");
    }

    /*
     * Incremement the level and add to the score.
     */
    private void onCakeSuccess()
    {
        score += points;
        customer.leaveStore();
        
    }

    /*
     * Creates a new customer
     */
    public void spawnCustomer()
    {
        customer = Instantiate(customerPreFab, customerSpawnPoint, Quaternion.identity).GetComponent<CustomerControler>();
    }

    private void setTargetCake()
    {

    }

}
