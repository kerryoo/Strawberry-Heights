using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryManager : GameManager
{
    private int score;
    private int level;
    private List<Texture> targetPastry;

    /*
     * Check if the targetPastry is the same as the textures. If it is, call
     * onPastrySuccess. If not, call onPastryFailure.
     */
    public void onPastrySubmit(List<Texture> textures)
    {

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

    }
}
