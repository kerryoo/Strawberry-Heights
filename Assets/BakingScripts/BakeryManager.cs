using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryManager : GameManager
{
    private int score = 0;
    private List<string> targetPastry = new List<string>();

    [SerializeField] int points;

    private void Start()
    {

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
}
