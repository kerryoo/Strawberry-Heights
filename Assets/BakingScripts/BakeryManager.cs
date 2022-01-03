using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BakeryManager : GameManager
{
    // Game management
    private List<string> targetPastry = new List<string>();
    

    // Scoring
    private int score = 0;
    [SerializeField] int points;

    // Customer
    [SerializeField] GameObject customerPreFab;
    [SerializeField] Vector3 customerSpawnPoint;

    private Stack<Vector3> line = new Stack<Vector3>();
    [SerializeField] int lineSeperation = 1;

    private void Start()
    {
        Vector3 subPadPos = GameObject.Find("Submission Pad").transform.position;
        line.Push(subPadPos + new Vector3(lineSeperation, 0, 0));

        spawnCustomer();
    }

    public Vector3 backOfLine()
    {
        if (line.Count > 0)
        {
            return line.Peek();
        }
        else
        {
            Debug.Log("SubmissionPad: Stack is empty, and it should not be.");
            return gameObject.transform.position + new Vector3(lineSeperation, 0, 0);
        }
    }

    public void AddToBack(Vector3 pos)
    {
        line.Push(pos + new Vector3(lineSeperation, 0, 0));
        Debug.Log(line.Peek());
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

    }

    /*
     * Incremement the level and add to the score.
     */
    private void onPastrySuccess()
    {
        score += points;
    }

    /*
     * Creates a new customer
     */
    public void spawnCustomer()
    {
        Instantiate(customerPreFab, customerSpawnPoint, Quaternion.identity);
    }
}
