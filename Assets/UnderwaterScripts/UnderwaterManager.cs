using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterManager : GameManager
{
    public GameObject pipe;
    int s;
    
    //sets the rate at which pipes spawn
    void setSpawningRate(int seconds)
    {
        s = seconds;
    }

    //will have to consider how to make sure pipes don't spawn where there are already objects
    void update()
    {
        if (Time.time % s == 0) {
            Instantiate(pipe); //TODO:Add random position parameter
        }
    }
}
