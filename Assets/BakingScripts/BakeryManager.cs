using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BakeryManager : GameManager
{
    // Game management
    private List<string> targetPastry = new List<string>();

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

    public void setTargetPastry(List<string> target)
    {
        targetPastry = target;
    }

    /*
     * Check if the targetPastry is the same as the textures. If it is, call
     * onPastrySuccess. If not, call onPastryFailure.
     */
    public void onPastrySubmit(List<string> decorations)
    {
        if (targetPastry.Count != decorations.Count)
        {
            onPastryFailure();
            return;
        }

        for (int i = 0; i < decorations.Count; ++i) 
        {
            if (targetPastry[i] != decorations[i])
            {
                onPastryFailure();
                return;
            }
        }

        onPastrySuccess();
    }

    /*
     * Do something when the player loses.
     */
    private void onPastryFailure()
    {
        bp.setText("That is not what I wanted");
    }

    /*
     * Incremement the level and add to the score.
     */
    private void onPastrySuccess()
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
}
